using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ThemesManager _themeManager;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _themeManager = GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<ThemesManager>();
        _themeManager.ThemeChanged += ChangeTheme;
    }

    private void ChangeTheme(object obj, int themeIndex)
    {
        _spriteRenderer.color = Utils.Themes[themeIndex].TextColor;
    }

    private void OnDestroy()
    {
        _themeManager.ThemeChanged -= ChangeTheme;
    }
}
