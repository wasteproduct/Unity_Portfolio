using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(Player_OrganizeTeam))]
public class Inspector_PlayerOrganizeTeam : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Select Character"))
        {

        }
    }
}
