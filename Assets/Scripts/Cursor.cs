using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Renderer myRenderer;
    public Transform target;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        StartCoroutine(Blink());
        //InvokeRepeating("Blink", 1f, 0.4f);
    }


    //IEnumerator Blink()
    //{
    //    Debug.Log("labas");
    //    myRenderer.enabled = false;
    //    yield return new WaitForSeconds(0.4f);
    //    myRenderer.enabled = true;
    //}

    private void Update()
    {
        Target();
    }
    void Target()
    {
        Vector3 targetPosition = Vector3.zero;
        targetPosition.x = target.GetComponent<Renderer>().bounds.max.x + 0.2f;
        targetPosition.y = target.GetComponent<Renderer>().bounds.center.y;
        transform.position = targetPosition;
    }

    IEnumerator Blink()
    {
        bool isEnabled = true;
        while (true)
        {
            isEnabled = !isEnabled;
            myRenderer.enabled = isEnabled;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
