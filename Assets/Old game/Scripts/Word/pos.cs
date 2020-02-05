using UnityEngine;

public class pos : MonoBehaviour
{
    public Vector3 CurrentPos { get; set; } = Vector3.zero;
    public float DistanceBetween_characters { get; set; } = 0.25f;

    private Transform cursor;
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
    }

    public void SetLetterPosition(char letterKey, GameObject letter)
    {
        GameInput.RemoveItem(letterKey, letter);
        letter.transform.tag = Tags.STRAINED_LETTER;
        letter.transform.SetParent(transform);
        letter.transform.GetComponent<Rigidbody>().isKinematic = true;
        //letterRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        var letterXSize = letter.GetComponent<Character>().CharacterLength / 2;
        CurrentPos = new Vector3(CurrentPos.x + letterXSize, 0, 0);

        var letterTrigger = letter.GetComponent<TriggerO>();
        letterTrigger.RemoveLetter(letterKey, letter);
        letterTrigger.ToPosition = CurrentPos;
        letterTrigger.IsToChangePosition = true;

        CurrentPos = new Vector3(CurrentPos.x + letterXSize + DistanceBetween_characters, 0, 0);
        cursor.transform.localPosition = CurrentPos;
    }
}
