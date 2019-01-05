using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Map_Main))]
public class Inspector_TileMap : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Tile Map"))
        {
            Map_Main mapMain = (Map_Main)target;
            mapMain.GenerateMap(true);

            EditorUtility.SetDirty(mapMain);
        }

        if (GUILayout.Button("Discard Map"))
        {
            Map_Main mapMain = (Map_Main)target;
            mapMain.DestroyMap();

            EditorUtility.SetDirty(mapMain);
        }

        if (GUILayout.Button("Clear Lists"))
        {
            Map_Main mapMain = (Map_Main)target;
            mapMain.Editor_ClearLists();

            EditorUtility.SetDirty(mapMain);
        }
    }
}
