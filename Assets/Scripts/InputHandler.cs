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
        }
        if (time2setup)
            SetupLetter(theLetter, theKey);

        isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in ascceptableLetters)
        {
            if (Input.GetKeyDown(vKey))
            {
                GameObject let = Instantiate(letter, this.transform);
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
                currentLetterPos -= transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x + distanceBetweenLetters;
                transform.position += new Vector3(transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x / 2, 0, 0);
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            }
            cursor.transform.position = new Vector3(transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.center.x + transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters/2, cursor.transform.position.y, 0);
        }
        
    }

    void SetupLetter(GameObject let, KeyCode vKey)
    {
        currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x/2;
        let.transform.localPosition = new Vector3(currentLetterPos, 0, 0);
        transform.position -= new Vector3(let.GetComponent<MeshRenderer>().bounds.size.x/2, 0, 0);
        currentLetterPos += let.GetComponent<MeshRenderer>().bounds.size.x / 2 + distanceBetweenLetters;
        Debug.Log(let.GetComponent<MeshRenderer>().bounds.size);
        time2setup = false;
    }
}
