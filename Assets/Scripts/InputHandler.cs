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
    void Start()
    {
        inputField = GetComponent<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {

        isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in ascceptableLetters)
        {
            if (Input.GetKeyDown(vKey))
            {
                GameObject let = Instantiate(letter, this.transform);
                let.GetComponent<Rigidbody>().isKinematic = true;
                if (!isUpperCase)
                {
                    let.GetComponent<TextMeshPro>().text = vKey.ToString().ToLower();
                }
                let.transform.localPosition = new Vector3(currentLetterPos, 0, 0);
                transform.position -= new Vector3(let.GetComponent<TextMeshPro>().GetRenderedValues(true).x / 2, 0, 0);
                currentLetterPos += let.GetComponent<TextMeshPro>().GetRenderedValues(true).x;
                Debug.Log(let.GetComponent<TextMeshPro>().GetRenderedValues(true).x);
            }
        }
    }
}
