using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Editor_Tester))]
public class Inspector_Tester : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Run"))
        {
            Editor_Tester tester = (Editor_Tester)target;
            tester.Run();

            EditorUtility.SetDirty(tester);
        }
    }
}
