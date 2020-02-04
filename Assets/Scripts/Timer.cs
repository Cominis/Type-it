using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float currentTime;

    private bool isCountingDown;

    public float startingTime;

    private TextMeshPro textMeshPro;



    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime = Mathf.Clamp(currentTime, 0, startingTime);

        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            int time = (int)currentTime;
            textMeshPro.text = $"{ time / 60:00}:{ time % 60:00}";

            if (currentTime <= 0f)
            {
                ResetClock();
                transform.parent.GetComponent<GameEnd>().EndGame();
            }
        }
    }

    public void Stop()
    {
        isCountingDown = false;
    }

    public void ResetClock()
    {
        Stop();
        currentTime = startingTime;
    }

    public void StartClock()
    {
        isCountingDown = true;
    }

    
}
