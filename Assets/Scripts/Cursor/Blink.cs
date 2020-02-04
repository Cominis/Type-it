using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        StartCoroutine(SetBlinking());
    }

    IEnumerator SetBlinking()
    {
        bool isEnabled = true;
        while (true)
        {
            isEnabled = !isEnabled;
            _renderer.enabled = isEnabled;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
