using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float Speed { get; set; } = 4f;
    public Vector3 ToPosition { get; set; }
    public bool IsToChangePosition { get; set; } = false;
    public char ThisLetterKey { get; set; }

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
            if (Vector3.Distance(transform.localPosition, ToPosition) < 0.01 && transform.eulerAngles.z < 3 && transform.eulerAngles.z > -3)
            {
                IsToChangePosition = false;
                //var collider = player.GetComponent<BoxCollider>();

                //var size = collider.size;
                //var center = collider.center;

                //var length = transform.GetComponent<MeshRenderer>().bounds.size.x;

                //collider.size = new Vector3(size.x + length, size.y, size.z);
                //collider.center = new Vector3(length / 2f + center.x, center.y, center.z);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, ToPosition, Speed * Time.deltaTime);
        }
    }
}
