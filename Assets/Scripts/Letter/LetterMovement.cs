using UnityEngine;

public class LetterMovement : MonoBehaviour
{
    public void Move()
    {
        var rg = gameObject.GetComponent<Rigidbody>();
        rg.isKinematic = false;
        rg.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8, 8), Random.Range(-8, -8), 0f);
        // GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20, 20), Random.Range(-20, -20), 0f));
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
