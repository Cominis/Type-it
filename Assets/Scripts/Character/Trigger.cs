using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //todo: disabled when tag is changed
    [SerializeField]
    private float _speed;

    private char _character;

    public float Speed { get => _speed; set => _speed = value; }
    public Vector3 ToPosition { get; set; }
    public bool IsToChangePosition { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.ACTIVE_ZONE && transform.tag == Tags.LOOSE_LETTER)
        {
            _character = transform.GetComponent<TextMeshPro>().text[0]; //todo: takes only one time

            //to activate input
            PlayerAttachment.ActivateLetter(_character, transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tags.ACTIVE_ZONE && transform.tag == Tags.LOOSE_LETTER)
        {
            //to deactivate input
            PlayerAttachment.DeactivateLetter(_character, transform);
        }
    }

    private void Update()
    {
        if (IsToChangePosition)
        {
            if (Vector3.Distance(transform.localPosition, ToPosition) < 0.1 && transform.eulerAngles.z < 1 && transform.eulerAngles.z > -1)
            {
                IsToChangePosition = false;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, ToPosition, Speed * Time.deltaTime);
        }
    }
}
