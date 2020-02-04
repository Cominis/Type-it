using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private float _speedX = 4f;
    private float _speedY = 4f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        _rigidBody2D.velocity = new Vector3(_speedX, -_speedY);
        // GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20, 20), Random.Range(-20, -20), 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _speedX = -_speedX;
        _speedY = -_speedY;
    }
}
