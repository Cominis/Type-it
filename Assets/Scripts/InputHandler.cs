using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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


    // Variables required for letter setup
    KeyCode theKey;
    GameObject theLetter;
    bool time2setup = false;


    void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        inputField = GetComponent<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        if ((ulong)GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().frame == GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().frameCount-1)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Video.VideoPlayer>().Stop();
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().ResetClock();
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().StartClock();
        }
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
            cursor.transform.position = new Vector3(transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.center.x + transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters/2, cursor.transform.position.y, 0);
            
        }
        
    }

    void SetupLetter(GameObject let, KeyCode vKey)
    {
        if (transform.childCount > 1)
            currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x/2;
        let.transform.localPosition = new Vector3(currentLetterPos, 0, 0);
        currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters;
        let.GetComponent<TextMeshPro>().color = new Color(0, 0, 0, 1);
        time2setup = false;
        transform.position = new Vector3(-Vector3.Distance(transform.GetChild(0).position, transform.GetChild(transform.childCount - 1).position) / 2, 0, 0);
    }
}
