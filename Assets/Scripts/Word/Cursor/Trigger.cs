using System;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float speed;
    private GameObject cursor;
    private GameObject player;
    [NonSerialized] public bool isTrue = false;
    private bool isTrue2 = false;
    private Vector3 toPosition;
    private float xLength;
    private Vector3 localPosition;
    private char itemKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            itemKey = transform.GetComponent<TextMeshPro>().text[0];
            GameInput.AddItem(itemKey, gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            GameInput.RemoveItem(itemKey, gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cursor = GameObject.FindGameObjectWithTag("Cursor");
    }
    private void Update()
    {
        if (isTrue)
        {
            transform.tag = Constants.LOCKED_LETTER;

            var rg = transform.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


            var otherRenderer = transform.GetComponent<Renderer>();
            xLength = (otherRenderer.bounds.max.x - otherRenderer.bounds.min.x) / 2;
            transform.SetParent(player.transform);

            //change position of letter that entered the zone
            localPosition = Vector3.zero;
            localPosition.x = cursor.transform.localPosition.x + xLength;
            toPosition = localPosition;

            isTrue2 = true;


            localPosition.x += xLength;
            cursor.transform.localPosition = localPosition;

            GameInput.RemoveItem(itemKey, gameObject);
            isTrue = false;
        }

        if (isTrue2)
        {
            if (Vector3.Distance(transform.localPosition, toPosition) < 0.1)
            {
                isTrue = false;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, toPosition, speed * Time.deltaTime);
        }
    }
}
