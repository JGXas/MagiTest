using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("MENUS")]
    [Tooltip("Canvas do Menu")]
    public GameObject mainMenu;
    [Tooltip("Menu Inicial")]
    public GameObject firstMenu;
    [Tooltip("Menu para a tela de PLAY")]
    public GameObject playMenu;
    [Tooltip("Menu para a tela de EXIT")]
    public GameObject exitMenu;

    [Header("PANELS")]
    [Tooltip("O Panel UI Parente de todos os menus")]
    public GameObject mainCanvas;
    [Tooltip("O Panel UI que da tela TAB VIDEO")]
    public GameObject PanelVideo;
    [Tooltip("O Panel UI que da tela TAB  GAME")]
    public GameObject PanelGame;

    [Header("LOADING SCREEN")]
    [Tooltip("Se for verdade, a cena não será carregada até receber o Imput do usuário")]
    public bool waitForInput = true;
    public GameObject loadingMenu;
    [Tooltip("O loading BAR UI da Tela de Loading")]
    public Slider loadingBar;
    public TMP_Text loadPromptText;
    public KeyCode userPromptKey;

    [Header("SFX")]
    [Tooltip("Componente Audio Source do HOVER SOUND")]
    public AudioSource hoverSound;
    [Tooltip("Componente Audio Source do AUDIO SLIDER")]
    public AudioSource sliderSound;
    [Tooltip("Componente Audio Source do SWOOSH SOUND quando for para a Tela de Cofigurações")]
    public AudioSource swooshSound;

    void Start()
    {
        playMenu.SetActive(false);
        exitMenu.SetActive(false);
        firstMenu.SetActive(true);
        mainMenu.SetActive(true);
    }

    public void PlayCampaign()
    {
        exitMenu.SetActive(false);
        playMenu.SetActive(true);
    }

    public void ReturnMenu()
    {
        playMenu.SetActive(false);
        exitMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void DisablePanels()
    {
        PanelVideo.SetActive(false);
        PanelGame.SetActive(false);
    }

    public void GamePanel()
    {
        DisablePanels();
        PanelGame.SetActive(true);
    }

    public void VideoPanel()
    {
        DisablePanels();
        PanelVideo.SetActive(true);
    }

    public void GeneralPanel()
    {
        DisablePanels();
    }

    public void PlayHover()
    {
        hoverSound.Play();
    }

    public void PlaySFXHover()
    {
        sliderSound.Play();
    }

    public void PlaySwoosh()
    {
        swooshSound.Play();
    }

    // Pop Up do Quit
    public void AreYouSure()
    {
        exitMenu.SetActive(true);
        DisablePlayCampaign();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
    }

    // Load Bar sincronizando com a Animação
    IEnumerator LoadAsynchronously(string sceneName)
    { // Nome da sena que será carregada
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        mainCanvas.SetActive(false);
        loadingMenu.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .95f);
            loadingBar.value = progress;

            if (operation.progress >= 0.9f && waitForInput)
            {
                loadPromptText.text = "Press " + userPromptKey.ToString().ToUpper() + " to continue";
                loadingBar.value = 1;

                if (Input.GetKeyDown(userPromptKey))
                {
                    operation.allowSceneActivation = true;
                }
            }
            else if (operation.progress >= 0.9f && !waitForInput)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void LoadScene(string scene)
    {
        if (scene != "")
        {
            StartCoroutine(LoadAsynchronously(scene));
        }
    }

    public void DisablePlayCampaign()
    {
        playMenu.SetActive(false);
    }
}
