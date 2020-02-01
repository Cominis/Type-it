using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform player;
    public Transform cursor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.FREE_LETTER)
        {
            other.tag = Constants.LOCKED_LETTER;

            var rg = other.transform.GetComponent<Rigidbody>();//.isKinematic = true;

            var otherRenderer = other.transform.GetComponent<Renderer>();
            var otherXLength = (otherRenderer.bounds.max.x - otherRenderer.bounds.min.x) / 2;
            other.transform.SetParent(player);

            //change position of letter that entered the zone
            Vector3 otherLocalPosition = Vector3.zero;
            otherLocalPosition.x = cursor.localPosition.x + otherXLength;
            //other.transform.localPosition = otherLocalPosition;

            rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            AddToWord(other.transform, otherLocalPosition);

            //change cursor pasotion
            //otherLocalPosition.x += otherXLength;
            //cursor.localPosition = otherLocalPosition;
        }
    }

    void AddToWord(Transform letterObj, Vector3 toPosition)
    {
        float speed = 2f;
        float condition = 1;
        int count = 50;
        float it = 0;
        while (it < 1)
        {
            it += Time.deltaTime;
            //if (Vector3.Distance(letterObj.localPosition, toPosition) < condition)
            //return;

            Debug.Log("from: " + letterObj.localPosition);
            Debug.Log("to: " + toPosition);
            //letterObj.position = Vector3.MoveTowards(letterObj.localPosition, toPosition, speed);
            letterObj.localPosition = Vector3.Lerp(letterObj.localPosition, toPosition, it);
        }

    }

}
