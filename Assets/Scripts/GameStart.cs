using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GameStart : MonoBehaviour
{
    public GameObject timerGameObject;
    public GameObject letter;
    private GameObject _player;

    private bool _isPlayable = false;
    private bool _isUpperCase;
    private VideoPlayer _intro;
    private GameEnd _gameEnd;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER);
        _intro = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VideoPlayer>();
        _intro.Play();
        _intro.loopPointReached += EndReached;
        _gameEnd = GetComponent<GameEnd>();
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

                string targetWord = "";
                _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);   // zone --> active
                var children = _player.transform.childCount - 1;
                while (children-- > 0)
                {
                    Transform fkey = _player.transform.GetChild(1);
                    fkey.SetParent(null);
                    fkey.gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
                    targetWord = String.Concat(targetWord, fkey.GetComponent<TextMeshPro>().text);
                }

                _gameEnd.word = targetWord;

                _player.GetComponent<Movement>().enabled = true;
                _player.GetComponent<LetterPositioning>().ResetCursor();
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
