using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR 
using UnityEditor;
#endif
using UnityEngine;

public class Option : MonoBehaviour
{
    public string phrase;
    [HideInInspector] public bool endDialog;
    [HideInInspector] public bool openDialogue;
    [HideInInspector] public bool executeAction;
    [HideInInspector] public Dialogue dialogue;
    [HideInInspector] public Action action;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Option))]
public class DAS_Option_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Option script = (Option)target;

        script.endDialog = EditorGUILayout.Toggle("End Dialogue", script.endDialog);
        if (!script.endDialog)
        {
            script.openDialogue = EditorGUILayout.Toggle("Open Dialogue", script.openDialogue);
            if (script.openDialogue)
            {
                script.dialogue = EditorGUILayout.ObjectField("Dialgoue", script.dialogue, typeof(Dialogue), true) as Dialogue;
            }

            script.executeAction = EditorGUILayout.Toggle("Execute Action", script.executeAction);
            if (script.executeAction)
            {
                script.action = EditorGUILayout.ObjectField("Action", script.action, typeof(Action), true) as Action;
            }
        } 
    }
}
#endif