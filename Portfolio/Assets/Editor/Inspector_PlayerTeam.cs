using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(Player_Team))]
public class Inspector_PlayerTeam : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
    }
}
