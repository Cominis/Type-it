using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTransition : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    public Vector3 ToPosition { get; set; }

    private void Update()
    {
        if (Vector3.Distance(transform.localPosition, ToPosition) < 0.1 && transform.eulerAngles.z < 1 && transform.eulerAngles.z > -1)
        {
            enabled = false;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, ToPosition, Speed * Time.deltaTime);
    }
}
