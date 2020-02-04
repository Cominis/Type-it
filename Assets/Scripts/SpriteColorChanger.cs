using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameTheme>().ColorChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, ThemeEventArgs args)
    {
        _spriteRenderer.color = args.TextColor;
        Debug.Log("color have been changed! " + gameObject.name);
    }
}
