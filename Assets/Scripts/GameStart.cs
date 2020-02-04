using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GameStart : MonoBehaviour
{
    public GameObject timerGameObject;
    public GameObject letter;
    private GameObject _player;

    private bool _isPlayable = true;
    private bool _isUpperCase;
    private VideoPlayer _intro;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER);
        _intro = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VideoPlayer>();
        //_intro.Play();
        _intro.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        _intro.Stop();
        _isPlayable = true;
    }
    void Update()
    {
        //if (time2setup)
        //SetupLetter(theLetter, theKey);
        if (_isPlayable)
        {

        
            _isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "A");

        
            foreach (KeyCode vKey in Constants.AcceptableKeys)
            {
                if (Input.GetKeyDown(vKey))
                {

                    //audio_src.clip = clickSounds[Random.Range(0, clickSounds.Length)];
                    //audio_src.Play();

                    GameObject typedLetter = Instantiate(letter, _player.transform);

                    //let.GetComponent<TextMeshPro>().color = new Color(let.GetComponent<TextMeshPro>().color.r, let.GetComponent<TextMeshPro>().color.g, let.GetComponent<TextMeshPro>().color.b, 0);

                    //time2setup = true;
                    StartCoroutine(CalculateBound(typedLetter));

                   
                    if (_isUpperCase)
                    {
                        typedLetter.GetComponent<TextMeshPro>().text = vKey.ToString();
                    }
                    else
                    {
                        typedLetter.GetComponent<TextMeshPro>().text = vKey.ToString().ToLower();
                    }

                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isPlayable = false;

                GameObject timer = Instantiate(timerGameObject, transform, false);
                timer.GetComponent<Timer>().StartClock();
                //for (int i = transform.childCount - 1; i > 0; i--)
                //{
                //    Transform fkey = transform.GetChild(i);
                //    word = fkey.GetComponent<TextMeshPro>().text + word;
                //    fkey.SetParent(null);
                //    var trigger = fkey.GetComponent<TriggerO>();

                //    trigger.IstoMove = true;
                //    trigger.ToPosition = new Vector3(Random.Range(-18, 18), Random.Range(-9, 9), 0);
                //    trigger.IsToChangePosition = true;
                //}



                //StartCoroutine(StartGame());
                //CreateLetters();
            }
        }

    }

    IEnumerator CalculateBound(GameObject typedLetter)
    {
        yield return new WaitForEndOfFrame();

        var boxCollider = typedLetter.AddComponent<BoxCollider2D>();
        var letterClass = typedLetter.GetComponent<Letter>();

        boxCollider.sharedMaterial = letterClass.Material;
        letterClass.LetterLength = boxCollider.bounds.size.x;

        Destroy(typedLetter.GetComponent<Rigidbody2D>());
        _player.GetComponent<LetterPositioning>().AddLetterInstantly(typedLetter.transform);
    }
}
