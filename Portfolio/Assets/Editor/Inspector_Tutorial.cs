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

        if (GUILayout.Button("Run"))
        {
            Tutorial_Manager tutorialManager = (Tutorial_Manager)target;
            tutorialManager.Run();

            EditorUtility.SetDirty(tutorialManager);
        }
    }
}
