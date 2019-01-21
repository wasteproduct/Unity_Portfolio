using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_TileMap_Current))]
public class Inspector_Tutorial_TileMap : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Discard Map"))
        {
            Tutorial_TileMap_Current tileMap = (Tutorial_TileMap_Current)target;
            tileMap.DiscardMap();

            EditorUtility.SetDirty(tileMap);
        }
    }
}
