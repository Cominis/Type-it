using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    private void Update()
    {
        Spin();
    }
    void Spin()
    {
        transform.Rotate(0, 0, Speed * Time.deltaTime);
    }

}
