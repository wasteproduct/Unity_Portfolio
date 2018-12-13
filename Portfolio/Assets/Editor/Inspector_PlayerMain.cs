using UnityEngine;
using UnityEditor;
using Player;

//using UnityEditor.SceneManagement;

[CustomEditor(typeof(Player_Main))]
public class Inspector_PlayerMain : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Add Character"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.AddCharacter();

            EditorUtility.SetDirty(playerMain);
        }

        if (GUILayout.Button("Clear List"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.ClearList();

            EditorUtility.SetDirty(playerMain);
        }

        if (GUILayout.Button("Refresh List"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.LoadData();

            EditorUtility.SetDirty(playerMain);
        }

        if (GUILayout.Button("Increase Strength"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.IncreaseStrength();

            EditorUtility.SetDirty(playerMain);
        }
    }
}
