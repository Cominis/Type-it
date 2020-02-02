using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Renderer myRenderer;
    void Start()
    {
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
