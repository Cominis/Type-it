using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _startingTime = -1;

    private float _currentTime = -1;

    private bool _isCountingDown = false;

    private TextMeshProUGUI _textMeshProUGUI;
    private EndManager _gameEnd;
    private ThemesManager _themeManager;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _gameEnd = transform.parent.GetComponent<EndManager>();
        _themeManager = transform.parent.GetComponent<ThemesManager>();
        _themeManager.ThemeChanged += ChangeTheme;

    }

    private void ChangeTheme(object obj, int themeIndex)
    {
        _textMeshProUGUI.color = Utils.Themes[themeIndex].TextColor;
    }

    private void OnDestroy()
    {
        _themeManager.ThemeChanged -= ChangeTheme;
    }

    void Update()
    {
        if (_isCountingDown)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0f)
        {
            _textMeshProUGUI.text = "Time is up!";
            ResetClock();
            _gameEnd.EndGame();
            return;
        }

        int time = (int)_currentTime;
        _textMeshProUGUI.text = $"{ time / 60:00}:{ time % 60:00}";
    }
    public void Stop() => _isCountingDown = false;
    public void Resume() => _isCountingDown = true;
    public void ResetClock()
    {
        Stop();
        _currentTime = _startingTime;
    }

    public void SetClock(float seconds) => _startingTime = seconds > 0 ? seconds : 0;

    public void StartClock()
    {
        _currentTime = _startingTime;
        _isCountingDown = true;
    }


    public void SetClockAndStart(float seconds)
    {
        SetClock(seconds);
        StartClock();
    }

}
