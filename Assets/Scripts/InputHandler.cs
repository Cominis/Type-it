using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public KeyCode[] ascceptableLetters;
    public GameObject letter;
    public float distanceBetweenLetters;

    private bool isUpperCase;
    private float currentLetterPos = 0;

    private TextMeshPro inputField;
    private MeshRenderer meshRenderer;
    public GameObject cursor;

    public AudioClip[] clickSounds;
    public AudioSource audio_src;

    public float pushForce;
    public float pushRotation;

    public GameObject cimMachine;
    public GameObject player;
    public GameObject timer;
    public GameObject mainCursor;
    public GameObject gameInput;


    // Variables required for letter setup
    KeyCode theKey;
    GameObject theLetter;
    bool time2setup = false;


    void Start()
    {
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        inputField = GetComponent<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        //if ((ulong)GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().frame == GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().frameCount - 1)
        //{
        //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().Stop();
        //}
        if (time2setup)
            SetupLetter(theLetter, theKey);

        isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in ascceptableLetters)
        {
            if (Input.GetKeyDown(vKey))
            {

                audio_src.clip = clickSounds[Random.Range(0, clickSounds.Length)];
                audio_src.Play();

                GameObject let = Instantiate(letter, this.transform);
                let.GetComponent<TextMeshPro>().color = new Color(0, 0, 0, 0);
                theKey = vKey;
                theLetter = let;
                time2setup = true;
                let.GetComponent<Rigidbody>().isKinematic = true;
                if (!isUpperCase)
                {
                    let.GetComponent<TextMeshPro>().text = vKey.ToString().ToLower();
                }
                else
                {
                    let.GetComponent<TextMeshPro>().text = vKey.ToString();
                }

            }
        }



        if (transform.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                audio_src.clip = clickSounds[Random.Range(0, clickSounds.Length)];
                audio_src.Play();
                currentLetterPos -= transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x + distanceBetweenLetters;
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
                transform.position = new Vector3(-Vector3.Distance(transform.GetChild(0).position, transform.GetChild(transform.childCount - 1).position) / 2, 0, 0);
            }
            cursor.transform.position = new Vector3(transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.center.x + transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters / 2, cursor.transform.position.y, 0);

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = transform.childCount - 1; i > 0; i--)
            {
                Transform fkey = transform.GetChild(i);
                fkey.SetParent(null);
                var trigger = fkey.GetComponent<Trigger>();
                trigger.ToPosition = new Vector3(Random.Range(-19, 18), Random.Range(-12, 24), 0);
                trigger.IsToChangePosition = true;
                //Vector3 startingForce = new Vector3(0, -4, 0);//new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);

                //startingForce.Normalize();
                //startingForce *= pushForce;
                //fkey.GetComponent<Rigidbody>().isKinematic = false;
                //fkey.GetComponent<Rigidbody>().AddForce(startingForce);
                //fkey.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * pushRotation;
            }



            StartCoroutine(StartGame());
        }

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        cimMachine.SetActive(true);
        var playerTransform = Instantiate(player).transform;
        cimMachine.GetComponent<CinemachineVirtualCamera>().Follow = playerTransform;
        GameObject tim = Instantiate(timer);
        tim.GetComponent<Timer>().StartClock();
        tim.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
        tim.transform.localPosition = new Vector3(-10, 5.5f, 2);



        //GameObject curs = Instantiate(mainCursor);
        //curs.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        //curs.GetComponent<Cursor>().firstLetter = transform.GetChild(0);

        var letter = transform.GetChild(0);

        var firstLetterRenderer = letter.GetComponent<MeshRenderer>();
        playerTransform.GetChild(0).localPosition = new Vector3(firstLetterRenderer.bounds.size.x / 2 + 0.25f, 0, 0);
        playerTransform.GetComponent<LetterPositioning>().CurrentPos = new Vector3(firstLetterRenderer.bounds.size.x / 2 + 0.25f, 0, 0);

        letter.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
        letter.tag = Constants.LOCKED_LETTER;

        Instantiate(gameInput);
        Destroy(cursor);
        Destroy(this);

    }
    void SetupLetter(GameObject let, KeyCode vKey)
    {
        if (transform.childCount > 1)
            currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x / 2;
        let.transform.localPosition = new Vector3(currentLetterPos, 0, 0);
        currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters;
        let.GetComponent<TextMeshPro>().color = new Color(0, 0, 0, 1);
        time2setup = false;
        transform.position = new Vector3(-Vector3.Distance(transform.GetChild(0).position, transform.GetChild(transform.childCount - 1).position) / 2, 0, 0);
        let.GetComponent<Letter>().LetterXSize = let.GetComponent<MeshRenderer>().bounds.size.x;
    }
}
