using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //todo: fix movement when tab is pressed
    //todo: fix movement disable
    [SerializeField]
    private float _speed = 4;
    private Rigidbody2D _rigidbody2D;
    private bool _isMovingAllowed = true;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isMovingAllowed && !Input.GetKey(KeyCode.Tab))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            _rigidbody2D.velocity = movement * _speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Tags.WALL)
        {
            StartCoroutine(DisableMovementBy(0.1f));
        }
    }

    IEnumerator DisableMovementBy(float time)
    {
        _isMovingAllowed = false;
        yield return new WaitForSeconds(time);
        _isMovingAllowed = true;
    }
}
