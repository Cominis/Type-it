using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 1;
    private Rigidbody Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput);

        Rigidbody.AddForce(movement * Speed);
    }
}
