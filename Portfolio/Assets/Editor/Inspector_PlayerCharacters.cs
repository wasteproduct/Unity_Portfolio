using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(UI_Window_PlayerCharacters))]
public class Inspector_PlayerCharacters : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Get Slots"))
        {
            UI_Window_PlayerCharacters playerCharacters = (UI_Window_PlayerCharacters)target;
            playerCharacters.Editor_GetSlots();

            EditorUtility.SetDirty(playerCharacters);
        }
    }
}
