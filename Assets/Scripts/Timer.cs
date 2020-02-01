using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;

    public bool isCountingDown;

    public float startingTime;

    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
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

    void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;
            text.text = Mathf.Round(currentTime).ToString();
        }
    }
}
