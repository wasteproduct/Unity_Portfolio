using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UI_Window_ComposeTeam))]
public class Inspector_ComposeTeam : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Get Slots"))
        {
            UI_Window_ComposeTeam composeTeam = (UI_Window_ComposeTeam)target;
            composeTeam.Editor_GetSlots();

            EditorUtility.SetDirty(composeTeam);
        }
    }
}
