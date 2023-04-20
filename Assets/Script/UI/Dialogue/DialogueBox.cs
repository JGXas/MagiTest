using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [HideInInspector] public DialogueSystem currentDialogueSystem;

    public string showUpAnimTrigger = "riseup";

    [Header("Dialogue Panel")]
    public GameObject dialogueNoOptions;
    public GameObject dialogueWithOptions;

    [Header("Dialogue Variables")]
    public TextMeshProUGUI titleNoPhoto;
    public TextMeshProUGUI phraseNoPhoto;

    [Header("Dialogue with photo variables")]
    public Image photo;
    public TextMeshProUGUI titlePhoto;
    public TextMeshProUGUI phrasePhoto;

    [Header("Options Variables")] 
    public GameObject option1Box;
    public TextMeshProUGUI option1Text;
    public GameObject option2Box;
    public TextMeshProUGUI option2Text;
    public GameObject option3Box;
    public TextMeshProUGUI option3Text;
    public GameObject option4Box;
    public TextMeshProUGUI option4Text;
    public GameObject option1CenterBox;
    public TextMeshProUGUI option1CenterText;
    public GameObject option2CenterBox;
    public TextMeshProUGUI option2CenterText;

    [Header("Single-Option Variables")]
    public GameObject singleOptionBox;
    public TextMeshProUGUI singleOptionText;

    [Header("Sound Variables")]
    public bool hasSound = false;
    public AudioSource dialogueBoxAudioSource;
    public AudioSource typingAudioSource;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void nextPhrase()
    {
        currentDialogueSystem.nextPhrase();
    }

    public void optionClick(int optionIndex)
    {
        currentDialogueSystem.executeOption(optionIndex);
    }

    public void showUpAnimation()
    {
        animator.SetTrigger(showUpAnimTrigger);
    }

    public void playDialogueBoxSound()
    {
        if (hasSound && dialogueBoxAudioSource)
        {
            dialogueBoxAudioSource.Play();
        }
    }

    public void playTypeSound()
    {
        if (hasSound && typingAudioSource)
        {
            typingAudioSource.loop = true;
            typingAudioSource.Play();
        }
    }

    public void stopTypeSound()
    {
        if (hasSound && typingAudioSource)
        {
            typingAudioSource.loop = false;
        }
    }
}
