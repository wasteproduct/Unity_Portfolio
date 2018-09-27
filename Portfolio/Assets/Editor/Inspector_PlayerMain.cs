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
            playerMain.AddCharacters();
            EditorUtility.SetDirty(playerMain);

            //EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (GUILayout.Button("Clear List"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.ClearCharacters();
        }

        if (GUILayout.Button("Print Character Information"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.PrintCharacterInformation();
        }

        if (GUILayout.Button("Increase Strength"))
        {
            Player_Main playerMain = (Player_Main)target;
            playerMain.IncreaseStrength();
        }
    }
}
