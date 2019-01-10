using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UI_QuestList))]
public class Inspector_QuestList : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Get Buttons"))
        {
            UI_QuestList questList = (UI_QuestList)target;
            questList.Editor_GetButtons();

            EditorUtility.SetDirty(questList);
        }
    }
}
