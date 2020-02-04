using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    public float Speed { get => _speed; set => _speed = value; }
    private Rigidbody2D Rigidbody2D { get; set; }
    private bool IsMovingAllowed { get; set; } = true;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsMovingAllowed && !Input.GetKey(KeyCode.Tab))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            Rigidbody2D.velocity = movement * Speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Constants.WALL)
        {
            StartCoroutine(DisableMovementBy(0.1f));
        }
    }

    IEnumerator DisableMovementBy(float time)
    {
        IsMovingAllowed = false;
        yield return new WaitForSeconds(time);
        IsMovingAllowed = true;
    }
}
