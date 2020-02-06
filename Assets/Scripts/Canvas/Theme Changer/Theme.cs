using UnityEngine;

public class Theme : MonoBehaviour
{
    public int ThemeIndex { get; set; }

    private ThemesManager _themesManager;
    private void Awake()
    {
        _themesManager = transform.parent.parent.parent.GetComponent<ThemesManager>(); //get canvas
    }
    public void SetTheme()
    {
        if (ThemeIndex != _themesManager.CurrentThemeIndex)
            _themesManager.OnThemeChanged(ThemeIndex);
    }
}
