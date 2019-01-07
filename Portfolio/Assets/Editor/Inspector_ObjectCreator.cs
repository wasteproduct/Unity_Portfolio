using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Editor_CreateObjects))]
public class Inspector_ObjectCreator : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Run"))
        {
            Editor_CreateObjects objectCreator = (Editor_CreateObjects)target;
            objectCreator.Run();

            EditorUtility.SetDirty(objectCreator);
        }
    }
}
