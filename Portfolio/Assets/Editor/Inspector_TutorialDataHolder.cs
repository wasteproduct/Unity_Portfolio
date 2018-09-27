using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_DataHolder))]
public class Inspector_TutorialData : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Add Data"))
        {
            Tutorial_DataHolder dataHolder = (Tutorial_DataHolder)target;
            dataHolder.AddData();

            EditorUtility.SetDirty(dataHolder);
        }

        if (GUILayout.Button("Clear Data"))
        {
            Tutorial_DataHolder dataHolder = (Tutorial_DataHolder)target;
            dataHolder.ClearData(true);

            EditorUtility.SetDirty(dataHolder);
        }

        if (GUILayout.Button("Print Data At"))
        {
            Tutorial_DataHolder dataHolder = (Tutorial_DataHolder)target;
            dataHolder.PrintData();

            EditorUtility.SetDirty(dataHolder);
        }

        if (GUILayout.Button("Add to Changed Integer"))
        {
            Tutorial_DataHolder dataHolder = (Tutorial_DataHolder)target;
            dataHolder.AddOneToChangedInteger();

            EditorUtility.SetDirty(dataHolder);
        }
    }
}
