using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Renderer myRenderer;
    public Transform firstLetter;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        StartCoroutine(Blink());
        StartCoroutine(SetCursor());
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

    IEnumerator SetCursor()
    {
        yield return new WaitForSeconds(0.2f);
        var firstLetterRenderer = firstLetter.GetComponent<MeshRenderer>();
        Vector3 position = Vector3.zero;
        position.x = firstLetterRenderer.bounds.size.x / 2;
        transform.localPosition = position;
    }
}
