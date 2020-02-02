using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float Speed { get; set; } = 12f;
    public Vector3 ToPosition { get; set; }
    public bool IsToChangePosition { get; set; } = false;
    public char ThisLetterKey { get; set; }
    public bool IstoMove { get; set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            ThisLetterKey = transform.GetComponent<TextMeshPro>().text[0];
            GameInput.AddItem(ThisLetterKey, gameObject);
            //Debug.Log(ThisLetterKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            GameInput.RemoveItem(ThisLetterKey, gameObject);
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
            if (Vector3.Distance(transform.localPosition, ToPosition) < 0.1 && transform.eulerAngles.z < 3 && transform.eulerAngles.z > -3)
            {
                IsToChangePosition = false;

                if (IstoMove)
                {
                    gameObject.GetComponent<LetterMovement>().Move();
                    IstoMove = false;
                }
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, ToPosition, Speed * Time.deltaTime);
        }
    }
}
