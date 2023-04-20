using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR 
using UnityEditor; 
#endif
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool lastOne;

    public string[] phrases;

    public Option[] options;

    [HideInInspector] public bool animatePhrases = true;
    [HideInInspector] public bool playTypingSound = true;

    [HideInInspector] public bool inheritStyle = true;
    [HideInInspector] public string title;
    [HideInInspector] public Sprite photo;

    [HideInInspector] public bool jumpToDialogue;
    [HideInInspector] public Dialogue targetDialogue;

    [HideInInspector] public bool playSpecificSound;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public AudioClip specificSound;

    public void playSound()
    {
        if (playSpecificSound && audioSource && specificSound)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(specificSound);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Dialogue))]
public class DAS_Dialogue_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Dialogue script = (Dialogue)target;

        script.inheritStyle = EditorGUILayout.Toggle("Inherit Style", script.inheritStyle);
        if (!script.inheritStyle)
        {
            script.title = EditorGUILayout.TextField("Title", script.title);
            script.photo = EditorGUILayout.ObjectField("Photo", script.photo, typeof(Sprite), true) as Sprite;
        }

        script.playSpecificSound = EditorGUILayout.Toggle("Play Specific Sound", script.playSpecificSound);
        if (script.playSpecificSound)
        {
            script.audioSource = EditorGUILayout.ObjectField("Audio Source", script.audioSource, typeof(AudioSource), true) as AudioSource;
            script.specificSound = EditorGUILayout.ObjectField("Specific Sound", script.specificSound, typeof(AudioClip), true) as AudioClip;
        }

        script.animatePhrases = EditorGUILayout.Toggle("Animate Phrases", script.animatePhrases);
        if (script.animatePhrases)
        {
            script.playTypingSound = EditorGUILayout.Toggle("Play Typing Sound", script.playTypingSound);
        }

        script.jumpToDialogue = EditorGUILayout.Toggle("Jump To Dialogue", script.jumpToDialogue);
        if (script.jumpToDialogue)
        {
            script.targetDialogue = EditorGUILayout.ObjectField("Target Dialgoue", script.targetDialogue, typeof(Dialogue), true) as Dialogue;
        }
    }
}
#endif