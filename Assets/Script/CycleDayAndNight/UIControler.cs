using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    private DayNight timeController;
    void Start()
    {
        timeController = FindObjectOfType<DayNight>();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        txtTime.text = timeController.currentTime.ToString("HH:mm");
    }
}
