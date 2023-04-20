using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayNight : MonoBehaviour
{
    [SerializeField] private float timeMultiplier, startHour, sunriseHour, sunsetHour;
    [HideInInspector] public DateTime currentTime;
    [HideInInspector] public TimeSpan sunriseTime, sunsetTime;

    private UIControler uiControleer;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        UpdateTimeOfDay();
    }

    private void Initialize()
    {
        uiControleer = FindObjectOfType<UIControler>();
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        uiControleer.UpdateText();
    }

    public TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
