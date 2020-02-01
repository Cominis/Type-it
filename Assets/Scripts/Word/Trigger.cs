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

            var rg = other.transform.GetComponent<Rigidbody>().isKinematic = true;

            var otherRenderer = other.transform.GetComponent<Renderer>();
            var otherXLength = (otherRenderer.bounds.max.x - otherRenderer.bounds.min.x) / 2;
            other.transform.parent = player;

            //change position of letter that entered the zone
            Vector3 otherLocalPosition = Vector3.zero;
            otherLocalPosition.x = cursor.localPosition.x + otherXLength;
            other.transform.localPosition = otherLocalPosition;

            //change cursor pasotion
            otherLocalPosition.x += otherXLength;
            cursor.localPosition = otherLocalPosition;
        }
    }

}
