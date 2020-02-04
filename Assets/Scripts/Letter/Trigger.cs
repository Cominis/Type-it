using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float Speed { get; set; } = 12f;
    public Vector3 ToPosition { get; set; }
    public bool IsToChangePosition { get; set; } = false;

    private char _letter;
    public bool IstoMove { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            _letter = transform.GetComponent<TextMeshPro>().text[0];

            //for input
            LetterAttachment.AddItem(_letter, transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            //for input
            LetterAttachment.RemoveItem(_letter, transform);
        }
    }

    public void RemoveLetter(char letterKey, GameObject letter)
    {
        GameInput.RemoveItem(letterKey, letter);
    }

    private void Update()
    {
        if (IsToChangePosition)
        {
            if (Vector3.Distance(transform.localPosition, ToPosition) < 0.1 && transform.eulerAngles.z < 1 && transform.eulerAngles.z > -1)
            {
                IsToChangePosition = false;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, ToPosition, Speed * Time.deltaTime);
        }
    }
}
