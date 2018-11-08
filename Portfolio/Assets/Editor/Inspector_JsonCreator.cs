using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Miscellaneous_JsonCreator))]
public class Inspector_JsonCreator : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Save"))
        {

        }
    }
}
