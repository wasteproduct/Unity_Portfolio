using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Manager_Quest))]
public class Inspector_QuestManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Get Buttons"))
        {
            Manager_Quest questManager = (Manager_Quest)target;
            questManager.Editor_GetButtons();

            EditorUtility.SetDirty(questManager);
        }
    }
}
