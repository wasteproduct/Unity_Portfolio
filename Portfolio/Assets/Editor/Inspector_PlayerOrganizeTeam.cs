﻿using UnityEngine;
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
            Player_OrganizeTeam organizeTeam = (Player_OrganizeTeam)target;
            organizeTeam.SelectCharacter();

            EditorUtility.SetDirty(organizeTeam);
        }

        if (GUILayout.Button("Add Team Fellow"))
        {
            Player_OrganizeTeam organizeTeam = (Player_OrganizeTeam)target;
            organizeTeam.AddTeamFellow();

            EditorUtility.SetDirty(organizeTeam);
        }
    }
}
