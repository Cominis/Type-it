using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Renderer myRenderer;
    public Transform firstLetter;
    void Start()
    {
        Debug.Log("yraeeeeeeeee?");

        var firstLetterRenderer = firstLetter.GetComponent<Renderer>();
        Vector3 position = Vector3.zero;
        position.x = (firstLetterRenderer.bounds.max.x - firstLetterRenderer.bounds.min.x) / 2;
        transform.localPosition = position;


        myRenderer = GetComponent<Renderer>();
        StartCoroutine(Blink());
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
