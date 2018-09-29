using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_Manager))]
public class Inspector_Tutorial : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Write json"))
        {
            Tutorial_Manager tutorialManager = (Tutorial_Manager)target;
            tutorialManager.WriteJSON();
            EditorUtility.SetDirty(tutorialManager);
        }

        if (GUILayout.Button("Add Character"))
        {
            Tutorial_Manager tutorialManager = (Tutorial_Manager)target;
            tutorialManager.AddCharacter();
            EditorUtility.SetDirty(tutorialManager);
        }
    }
}
