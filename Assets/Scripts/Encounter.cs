using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        //var joint = transform.GetComponent<DistanceJoint2D>();
        //joint.connectedBody = collider.GetComponent<Rigidbody2D>();
        Destroy(collider.gameObject);
    }
}
