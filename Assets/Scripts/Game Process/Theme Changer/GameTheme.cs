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
        if (_currentThemeIndex != value && value < Utils.Themes.Count && value >= 0)
        {
            _currentThemeIndex = value;
            _currentTheme = Utils.Themes[value];
            OnColorChanged();
        }

    }

    public event EventHandler<ThemeEventArgs> ColorChanged;
    public void OnColorChanged()
    {
        //Debug.Log("bc color: " + _currentTheme.BackgraoundColor);
        //Debug.Log("BEFORE camera color: " + _mainCamera.backgroundColor);
        _mainCamera.backgroundColor = _currentTheme.BackgraoundColor;
        //Debug.Log("AFTER camera color: " + _mainCamera.backgroundColor);

        ColorChanged?.Invoke(null, _currentTheme);
    }

}
