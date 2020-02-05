using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TextColorChanger : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private GameTheme _gameTheme;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _gameTheme = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameTheme>();
        _gameTheme.ColorChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, ThemeEventArgs args)
    {
        _textMeshPro.color = args.TextColor;
    }

    private void OnDestroy()
    {
        _gameTheme.ColorChanged -= ChangeTheme;
    }
}
