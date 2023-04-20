using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMinigame : MonoBehaviour
{
    [Header("Config Transform")]
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [Header("Config Fire")]
    [SerializeField] Transform fireMarker;

    float firePosition;
    float fireDestination;

    float fireTimer;
    [SerializeField] float timerMultiplicator = 5f;

    float fireSpeed;
    [SerializeField] float smoothMotion = 1f;

    [Header("Config Control")]
    [SerializeField] Transform control;
    float controlPosition;
    [SerializeField] float controlSize = 0.1f;
    [SerializeField] float controlPower = 0.5f;
    float controlProgress;
    float controlPullVelocity;
    [SerializeField] float controlPullPower = 0.01f;
    [SerializeField] float controlGravityPower = 0.005f;
    [SerializeField] float controlProgressDegradationPower = 0.1f;

    [Header("Config Progress")]
    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 10f;

    private void Update()
    {
        if (pause) return;

        Fire();
        Control();
        ProgressCheck();
    }

    void Fire()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer < 0f)
        {
            fireTimer = UnityEngine.Random.value * timerMultiplicator;
            fireDestination = UnityEngine.Random.value;
        }

        firePosition = Mathf.SmoothDamp(firePosition, fireDestination, ref fireSpeed, smoothMotion);
        fireMarker.position = Vector3.Lerp(bottomPivot.position, topPivot.position, firePosition);
    }

    void Control()
    {
        if (Input.GetMouseButton(0)) //Mudar Input
        {
            controlPullVelocity += controlPullPower * Time.deltaTime;
        }
        else
        {
            controlPullVelocity -= controlGravityPower * Time.deltaTime;
        }

        controlPosition += controlPullVelocity;

        if (controlPosition - controlSize / 2 <= 0f && controlPullVelocity < 0f)
        {
            controlPullVelocity = 0f;
        }
        if (controlPosition + controlSize / 2 >= 1f && controlPullVelocity > 0f)
        {
            controlPullVelocity = 0f;
        }

        controlPosition = Mathf.Clamp(controlPosition, controlSize/2, 1 - controlSize/2);
        control.position = Vector3.Lerp(bottomPivot.position, topPivot.position, controlPosition);
    }

    void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = controlProgress;
        progressBarContainer.localScale = ls;

        float min = controlPosition - controlSize/2;
        float max = controlPosition + controlSize/2;

        if (min < firePosition && firePosition < max)
        {
            controlProgress += controlPower * Time.deltaTime;
        }
        else
        {
            controlProgress -= controlProgressDegradationPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if (failTimer < 0f)
            {
                Lose();
            }
        }

        if(controlProgress >= 1f)
        {
            Win();
        }

        controlProgress = Mathf.Clamp(0f, controlProgress, 0f);
    }

    void Win()
    {
        pause = true;
        Debug.Log("VOCE VENCEU");
    }

    void Lose()
    {
        pause = true;
        Debug.Log("VOCE PERDEU");
    }
}
