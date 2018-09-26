using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(Manager_BaseCamp))]
public class Inspector_BaseCamp : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Open Characters"))
        {
            Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;

            Player_Characters playerCharacters = baseCamp.GetComponent<Player_Characters>();
            playerCharacters.OpenCharacters();
        }

        if (GUILayout.Button("Close Characters"))
        {
            Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;

            Player_Characters playerCharacters = baseCamp.GetComponent<Player_Characters>();
            playerCharacters.CloseCharacters();
        }

        if (GUILayout.Button("Open Organize Team"))
        {

        }

        if (GUILayout.Button("Close Organize Team"))
        {

        }
    }
}
