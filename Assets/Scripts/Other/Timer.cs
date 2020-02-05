using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float _startingTime = -1;

    private float _currentTime = -1;

    private bool _isCountingDown = false;

    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (_isCountingDown)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0f)
            {
                _textMeshPro.text = "Time is up!";
                ResetClock();
                transform.parent.GetComponent<GameEnd>().EndGame();
                return;
            }

            int time = (int)_currentTime;
            _textMeshPro.text = $"{ time / 60:00}:{ time % 60:00}";
        }
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
