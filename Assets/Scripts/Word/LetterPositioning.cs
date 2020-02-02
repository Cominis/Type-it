using UnityEngine;

public class LetterPositioning : MonoBehaviour
{
    public Vector3 CurrentPos { get; set; } = Vector3.zero;
    public float DistanceBetweenLetters { get; set; } = 0.25f;

    private Transform cursor;
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
    }

    public void SetLetterPosition(char letterKey, GameObject letter)
    {
        GameInput.RemoveItem(letterKey, letter);

        letter.transform.tag = Constants.LOCKED_LETTER;
        letter.transform.SetParent(transform);
        letter.transform.GetComponent<Rigidbody>().isKinematic = true;
        //letterRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        var letterXSize = letter.transform.GetComponent<MeshRenderer>().bounds.size.x / 2f;
        CurrentPos = new Vector3(CurrentPos.x + letterXSize, 0, 0);

        var letterTrigger = letter.GetComponent<Trigger>();
        letterTrigger.RemoveLetter(letterKey, letter);
        letterTrigger.ToPosition = CurrentPos;
        letterTrigger.IsToChangePosition = true;

        CurrentPos = new Vector3(CurrentPos.x + letterXSize + DistanceBetweenLetters, 0, 0);
        cursor.transform.localPosition = CurrentPos;
    }
}
