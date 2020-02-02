using UnityEngine;

public class LetterMovement : MonoBehaviour
{
    public void Move()
    {
        var rg = gameObject.GetComponent<Rigidbody>();
        rg.isKinematic = false;
        rg.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, -10), 0f);
        // GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20, 20), Random.Range(-20, -20), 0f));
    }
}
