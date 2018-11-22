using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_SoundTest))]
public class Inspector_Tutorial_Sound : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Play"))
        {
            Tutorial_SoundTest soundTest = (Tutorial_SoundTest)target;
            soundTest.Play();

            EditorUtility.SetDirty(soundTest);
        }
    }
}
