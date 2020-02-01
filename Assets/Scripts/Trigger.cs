using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public Transform player;
    public Transform cursor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constants.FREE_LETTER)
        {
            other.tag = Constants.LOCKED_LETTER;
            var otherRenderer = other.transform.GetComponent<Renderer>();

            other.transform.parent = player;

            Vector3 otherLocalPosition = Vector3.zero;
            otherLocalPosition.x = transform.parent.localPosition.x + otherRenderer.bounds.min.x;
            other.transform.localPosition = otherLocalPosition;

            //otherLocalPosition.x = 4f;
            //cursor.localPosition = otherLocalPosition;
            Debug.Log(transform.parent.localPosition.x);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Destroy everything that leaves the trigger
        //Destroy(other.gameObject);
    }

}
public static class TriggerEvents
{
    public static TriggerEvent triggered = new TriggerEvent();
}
public class TriggerEvent : UnityEvent<TriggerEventData> { }
public class TriggerEventData
{
    public Transform letterTransform { get; private set; }
    public KeyCode letterKeyCode { get; private set; }

    public TriggerEventData(Transform letterTransform, KeyCode letterKeyCode)
    {
        this.letterTransform = letterTransform;
        this.letterKeyCode = letterKeyCode;
    }
}
