using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    private float _speedX = 0f;
    private float _speedY = 0f;

    private const float MIN_SPEED = 0.5f;
    private const float MAX_SPEED = 2f;

    private void FixedUpdate()
    {
        _rigidBody2D.AddForce(new Vector2(_speedX, _speedY), ForceMode2D.Impulse);
        enabled = false;
    }
    public void Move()
    {
        _speedX = UnityEngine.Random.Range(MIN_SPEED, MAX_SPEED) * (UnityEngine.Random.Range(0, 2) * 2 - 1);
        _speedY = UnityEngine.Random.Range(MIN_SPEED, MAX_SPEED) * (UnityEngine.Random.Range(0, 2) * 2 - 1);
        _rigidBody2D = GetComponent<Rigidbody2D>(); // referencing here because rigidbody
        //StartCoroutine(StopMoving()); //todo: ForceMode2D force or impulse?
        //Debug.Log(_speedX + " : " + _speedY);
        enabled = true;
        
    }

    private IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(3f);
    }
}
