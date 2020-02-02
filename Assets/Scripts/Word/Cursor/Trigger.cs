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
    private char itemKey;
    public float spaceSize;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zone" && transform.tag == Constants.FREE_LETTER)
        {
            itemKey = transform.GetComponent<TextMeshPro>().text[0];
            GameInput.AddItem(itemKey, gameObject);
            Debug.Log(itemKey);
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
            GameInput.RemoveItem(itemKey, gameObject);

            transform.tag = Constants.LOCKED_LETTER;

            var rg = transform.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            //xLength = transform.GetComponent<Renderer>().bounds.size.x / 2;
            var xLength = transform.GetComponent<MeshCollider>().bounds.size.x / 2f;
            transform.SetParent(player.transform);

            //change position of letter that entered the zone
            var localPosition = Vector3.zero;
            localPosition.x = cursor.transform.localPosition.x + xLength + spaceSize;
            toPosition = localPosition;

            isTrue2 = true;


            localPosition.x += xLength;
            cursor.transform.localPosition = localPosition;


            isTrue = false;
        }

        if (isTrue2)
        {
            if (Vector3.Distance(transform.localPosition, toPosition) < 0.1 && transform.eulerAngles.z < 3 && transform.eulerAngles.z > -3)
            {
                isTrue2 = false;
                var collider = player.GetComponent<BoxCollider>();

                var size = collider.size;
                var center = collider.center;

                var length = transform.GetComponent<MeshCollider>().bounds.size.x;

                collider.size = new Vector3(size.x + length, size.y, size.z);
                collider.center = new Vector3(length / 2f + center.x, center.y, center.z);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, toPosition, speed * Time.deltaTime);
        }
    }
}
