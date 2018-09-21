using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Manager_BaseCamp))]
public class Inspector_BaseCamp : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Characters"))
        {

        }

        if (GUILayout.Button("Organize Team"))
        {

        }
    }
}
