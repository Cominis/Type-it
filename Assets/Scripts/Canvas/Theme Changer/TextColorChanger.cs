using TMPro;
using UnityEngine;
public class TextColorChanger : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private ThemesManager _themeManager;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _themeManager = GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<ThemesManager>();
        _themeManager.ThemeChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, int themeIndex)
    {
        _textMeshPro.color = Utils.Themes[themeIndex].TextColor;
    }

    private void OnDestroy()
    {
        _themeManager.ThemeChanged -= ChangeTheme;
    }
}
