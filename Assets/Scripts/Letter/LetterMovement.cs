using UnityEngine;

public class LetterMovement : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, -10), 0);
    }
}
