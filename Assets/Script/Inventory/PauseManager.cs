using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject itemPopUp;

    public static bool Paused = false;

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PauseInventory()
    {
        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void PauseItemPopUp()
    {
        itemPopUp.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void ResumeInventory()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }

    public void ResumeItemPopUp()
    {
        itemPopUp.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }

    /*
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
