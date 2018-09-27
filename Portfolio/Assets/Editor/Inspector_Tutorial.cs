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
    }
}
