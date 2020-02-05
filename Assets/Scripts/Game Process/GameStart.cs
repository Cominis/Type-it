using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GameStart : MonoBehaviour
{
    //todo: make camera to follow player
    //todo: make line effect on wall when item hit it
    //todo: make zone particles with force
    public GameObject timer = null;
    public GameObject character;
    
    private bool _isGamePlayable = true;
    private bool _isUpperCase;

    private GameObject _player;
    private VideoPlayer _intro;
    private GameEnd _gameEnd;   //todo: is it nessasary to hold it?
    private CursorPositioning _cursorPositioning;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _cursorPositioning = _player.transform.GetChild(0).GetComponent<CursorPositioning>();
        _gameEnd = GetComponent<GameEnd>();

        _intro = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<VideoPlayer>();
        _intro.loopPointReached += EndReached;
        //_intro.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        _intro.Stop();
        _isGamePlayable = true;
    }

    //todo: KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "A");
    void Update()
    {
        if (_isGamePlayable)
        {
            _isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            foreach (KeyCode vKey in Utils.AcceptableKeys)
            {
                if (Input.GetKeyDown(vKey))
                {
                    GameObject typedCharacter = Instantiate(character, _player.transform);
                    typedCharacter.GetComponent<TextMeshPro>().text = 
                        _isUpperCase ? vKey.ToString() : vKey.ToString().ToLower();

                    StartCoroutine(SetupCharacter(typedCharacter));
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isGamePlayable = false;

                InstantiateTimer();
                _gameEnd.word = _cursorPositioning.LooseCharacters();
                _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);   // zone --> active
                _player.GetComponent<PlayerMovement>().enabled = true;


                StartCoroutine(GenerateRandomCharacters());
            }
        }

    }

    //todo: optimize
    IEnumerator GenerateRandomCharacters()
    {
        for (int i = 0; i < 5; i++)
        {
            var x = UnityEngine.Random.Range(5f, 10f) * (UnityEngine.Random.Range(0, 2) * 2 - 1);
            var y = UnityEngine.Random.Range(5f, 10f) * (UnityEngine.Random.Range(0, 2) * 2 - 1);
            GameObject typedCharacter = Instantiate(character, new Vector3(x, y, 0), Quaternion.identity);
            typedCharacter.GetComponent<TextMeshPro>().text = Constants.characters[UnityEngine.Random.Range(0, Constants.characters.Length)].ToString();
            yield return new WaitForEndOfFrame();
            var boxCollider = typedCharacter.AddComponent<BoxCollider2D>();
            var letterClass = typedCharacter.GetComponent<Character>();
            letterClass.CharacterLength = boxCollider.bounds.size.x;
            boxCollider.sharedMaterial = letterClass.Material;  //todo: material is added only in this class
            //typedLetter.GetComponent<TextMeshPro>().color = new Color(let.GetComponent<TextMeshPro>().color.r, let.GetComponent<TextMeshPro>().color.g, let.GetComponent<TextMeshPro>().color.b, 0);
            
            typedCharacter.GetComponent<RandomMovement>().Move();
        }
    }
    private void InstantiateTimer()
    {
        GameObject timerObj = Instantiate(timer, transform, false);
        timerObj.GetComponent<Timer>().SetClockAndStart(15f); //todo: do something with timer
    }
    IEnumerator SetupCharacter(GameObject typedLetter)
    {
        yield return new WaitForEndOfFrame();

        var boxCollider = typedLetter.AddComponent<BoxCollider2D>();
        var letterClass = typedLetter.GetComponent<Character>();
        letterClass.CharacterLength = boxCollider.bounds.size.x;
        _cursorPositioning.AddCharacterInstantly(typedLetter.transform);
        boxCollider.sharedMaterial = letterClass.Material;
        //typedLetter.GetComponent<TextMeshPro>().color = new Color(let.GetComponent<TextMeshPro>().color.r, let.GetComponent<TextMeshPro>().color.g, let.GetComponent<TextMeshPro>().color.b, 0);
        //todo: change color of new character
    }
}
