using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class StartManager : MonoBehaviour
{
    //todo: make line effect on wall when item hit it
    //todo: make zone particles with force
    public GameObject character;

    //private bool _isGamePlayable;
    private bool _isUpperCase;

    private GameObject _player;
    //private VideoPlayer _intro;
    private EndManager _gameEnd;   //todo: is it nessasary to hold it?
    private CursorPositioning _cursorPositioning;
    private ThemesManager _themesManager;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _cursorPositioning = _player.transform.GetChild(0).GetChild(0).GetComponent<CursorPositioning>();
        _gameEnd = GetComponent<EndManager>();

        _themesManager = GetComponent<ThemesManager>();
    }

    //todo: KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "A");
    void Update()
    {
        _isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in Utils.AcceptableKeys)
        {
            if (Input.GetKeyDown(vKey))
            {
                GameObject typedCharacter = Instantiate(character, new Vector3(300, 300, 0), Quaternion.identity, _player.transform.GetChild(0));  // parent --> characters holder

                typedCharacter.GetComponent<TextMeshPro>().text =
                    _isUpperCase ? vKey.ToString() : vKey.ToString().ToLower();

                StartCoroutine(SetupCharacter(typedCharacter));
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            InstantiateTimer();
            _gameEnd.word = _cursorPositioning.LooseCharacters();
            _player.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);   // zone --> active
            _player.GetComponent<PlayerMovement>().enabled = true;


            StartCoroutine(GenerateRandomCharacters(20));
            enabled = false;
        }
    }

    //todo: optimize
    IEnumerator GenerateRandomCharacters(int amount)
    {
        var minX = WallProps.MinX + 1;
        var maxX = WallProps.MaxX - 1;
        var minY = WallProps.MinY + 1;
        var maxY = WallProps.MaxY - 1;

        for (int i = 0; i < amount; i++)
        {

            var x = UnityEngine.Random.Range(minX, maxX);
            var y = UnityEngine.Random.Range(minY, maxY);
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
        transform.GetChild(1).GetComponent<Timer>().SetClockAndStart(60f); //todo: do something with timer
    }
    IEnumerator SetupCharacter(GameObject typedCharacter)
    {
        yield return new WaitForEndOfFrame();

        var boxCollider = typedCharacter.AddComponent<BoxCollider2D>();
        var letterClass = typedCharacter.GetComponent<Character>();
        letterClass.CharacterLength = boxCollider.bounds.size.x;
        _cursorPositioning.AddCharacterInstantly(typedCharacter.transform);
        boxCollider.sharedMaterial = letterClass.Material;
        //typedLetter.GetComponent<TextMeshPro>().color = new Color(let.GetComponent<TextMeshPro>().color.r, let.GetComponent<TextMeshPro>().color.g, let.GetComponent<TextMeshPro>().color.b, 0);
        //todo: change color of new character
    }
}
