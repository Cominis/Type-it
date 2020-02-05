using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private GameTheme _gameTheme;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameTheme = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameTheme>();
        _gameTheme.ColorChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, ThemeEventArgs args)
    {
        _spriteRenderer.color = args.TextColor;
    }

    private void OnDestroy()
    {
        _gameTheme.ColorChanged -= ChangeTheme;
    }
}
