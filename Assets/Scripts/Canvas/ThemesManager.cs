using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemesManager : MonoBehaviour
{
    public GameObject theme;
    public int CurrentThemeIndex { get; set; } = 0;

    public Texture2D cursorTexture;
    public ThemeEventArgs CurrentTheme { get; set; } = Utils.Themes[0];
    void Awake()
    {
        var layout = transform.GetChild(0).GetChild(0);
        for (int i = 0; i < Utils.Themes.Count; i++)
        {
            var button = Instantiate(theme, layout, false);
            button.GetComponent<ThemeChangeTrigger>().ThemeIndex = i;
            button.transform.GetChild(0).GetComponent<Image>().color = Utils.Themes[i].BackgraoundColor;
            button.transform.GetChild(1).GetComponent<Image>().color = Utils.Themes[i].TextColor;
        }
    }

    public event EventHandler<int> ThemeChanged;
    public void OnThemeChanged(int themeIndex)
    {
        CurrentThemeIndex = themeIndex;
        Camera.main.backgroundColor = Utils.Themes[themeIndex].BackgraoundColor;
        SetCursorColor(themeIndex);
        ThemeChanged?.Invoke(null, themeIndex);
    }

    private void SetCursorColor(int themeIndex)
    {
        var colors = cursorTexture.GetPixels32();
        for (int i = 0; i < colors.Length; i++)
        {
            var alpha = colors[i].a;
            colors[i] = Utils.Themes[themeIndex].TextColor;
            colors[i].a = alpha;
        }
        cursorTexture.SetPixels32(colors);
        Cursor.SetCursor(cursorTexture, new Vector2(2, 2), CursorMode.Auto);
    }
}
