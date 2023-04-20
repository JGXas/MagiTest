using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light sunLight, moonLight;
    [SerializeField] private List<Light> constructionLight, flashLight;
    [SerializeField] private Color dayAmbientLight, nightAmbientLight;
    [SerializeField] private AnimationCurve ambientLightCurve, skyboxTransictionCurve, enviromentTransitionCurve;
    [SerializeField] private float maxSunLightIntensity, maxMoonLightIntensity, constructionLightIntensity, flashLightIntensity;

    private DayNight timeController;
    private SkyBoxController skyboxController;
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        RotateSun();
        UpdateLightSettingsandSkybox();
    }

    private void Initialize()
    {
        timeController = FindObjectOfType<DayNight>();
        skyboxController = FindObjectOfType<SkyBoxController>();
        sunLight.color = dayAmbientLight;
        moonLight.color = nightAmbientLight;
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if(timeController.currentTime.TimeOfDay > timeController.sunriseTime && timeController.currentTime.TimeOfDay < timeController.sunsetTime)
        {
            //Dia
            TimeSpan sunriseToSunsetDuration = timeController.CalculateTimeDifference(timeController.sunriseTime, timeController.sunsetTime);
            TimeSpan timeSinceSunrise = timeController.CalculateTimeDifference(timeController.sunriseTime, timeController.currentTime.TimeOfDay);
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0f, 180f, (float)percentage);
        }
        else 
        {
            //Noite
            TimeSpan sunsetToSunriseDuration = timeController.CalculateTimeDifference(timeController.sunsetTime, timeController.sunriseTime);
            TimeSpan timeSinceSunset = timeController.CalculateTimeDifference(timeController.sunsetTime, timeController.currentTime.TimeOfDay);
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180f, 360f, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettingsandSkybox()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);

        ChangeLightintensity(sunLight, 0f, maxSunLightIntensity, dotProduct, ambientLightCurve);
        ChangeLightintensity(moonLight, maxMoonLightIntensity, 0f, dotProduct, ambientLightCurve);
        //ChangeLightintensity(constructionLight, constructionLightIntensity, 0f, dotProduct, enviromentTransitionCurve);
        //ChangeLightintensity(flashLight, flashLightIntensity, 0f, dotProduct, enviromentTransitionCurve);

        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, ambientLightCurve.Evaluate(dotProduct));
        skyboxController.blend = Mathf.Lerp(1f, 0f, skyboxTransictionCurve.Evaluate(dotProduct));
    }

    private void ChangeLightintensity(Light targetLight, float lerpA, float lerpB, float dotProduct, AnimationCurve timeCurve)
    {
        targetLight.intensity = Mathf.Lerp(lerpA, lerpB, timeCurve.Evaluate(dotProduct));
    }
}
