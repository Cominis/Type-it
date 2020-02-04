using UnityEngine;

public class GameColors : MonoBehaviour
{
    private bool _updateTheme = false;
    private int _currentTheme;
    private int CurrentTheme
    {
        get => _currentTheme;
        set
        {
            var oldTheme = _currentTheme;
            _currentTheme = value;
            if (oldTheme != _currentTheme)
                _updateTheme = true;
        }
    }

    public GameObject wall;
    public GameObject correctMark;
    public GameObject wrongMark;
    public GameObject letter;
    public GameObject timer;
    public GameObject cursor;

    private void Update()
    {
        if (_updateTheme)
        {
            wall.GetComponent<SpriteRenderer>().color =
            //update all
        }
    }

    public void SetTheme(int theme)
    {
        if (theme < Constants.Themes.Count)
        {
            CurrentTheme = theme;
        }
    }
}
