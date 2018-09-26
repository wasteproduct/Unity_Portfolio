using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(Player_Characters))]
public class Inspector_PlayerCharacters : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Select Character"))
        {
            Player_Characters playerCharacters = (Player_Characters)target;
            playerCharacters.SelectCharacter();
        }
    }
}
