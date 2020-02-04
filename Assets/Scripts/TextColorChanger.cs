using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TextColorChanger : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameTheme>().ColorChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, ThemeEventArgs args)
    {

        Debug.Log("color have been changed! " + gameObject.name);
        _textMeshPro.color = args.TextColor;
    }
}
