using System.Collections;
using UnityEngine;

public class LetterStart : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SetBoundary());
    }

    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(0.5f);
        var playerCollider = transform.parent.GetComponent<BoxCollider>();
        var firstLetterRenderer = transform.GetComponent<Renderer>();
        playerCollider.size = firstLetterRenderer.bounds.size;
    }
}
