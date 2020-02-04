using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRigid : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var rg = collision.gameObject.GetComponent<Rigidbody>();
        Destroy(rg);
        //collision.gameObject.AddComponent<Rigidbody>();
    }
}
