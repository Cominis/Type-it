using System;
using UnityEngine;

public class GameTheme : MonoBehaviour
{
    private int _currentThemeIndex = -1;
    private ThemeEventArgs _currentTheme;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<Camera>();
    }
    public void SetCurrentTheme(int value)
    {
        if (_currentThemeIndex != value && value < Constants.Themes.Count && value >= 0)
        {
            _currentThemeIndex = value;
            _currentTheme = Constants.Themes[value];
            OnColorChanged();
        }

    }

    public event EventHandler<ThemeEventArgs> ColorChanged;
    public void OnColorChanged()
    {
        _mainCamera.backgroundColor = _currentTheme.BackgraoundColor;
        ColorChanged?.Invoke(null, _currentTheme);
    }

    
}
