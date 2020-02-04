using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    private void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        transform.Rotate(0, 0, Speed * Time.deltaTime);
    }
}
