using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_TileMap))]
public class Inspector_Tutorial_TileMap : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Map Pattern 1"))
        {
            Tutorial_TileMap tileMap = (Tutorial_TileMap)target;
            tileMap.GenerateMap(1);

            EditorUtility.SetDirty(tileMap);
        }

        if (GUILayout.Button("Generate Map Pattern 2"))
        {
            Tutorial_TileMap tileMap = (Tutorial_TileMap)target;
            tileMap.GenerateMap(2);

            EditorUtility.SetDirty(tileMap);
        }

        if (GUILayout.Button("Generate Map Pattern 3"))
        {
            Tutorial_TileMap tileMap = (Tutorial_TileMap)target;
            tileMap.GenerateMap(3);

            EditorUtility.SetDirty(tileMap);
        }

        if (GUILayout.Button("Discard Map"))
        {
            Tutorial_TileMap tileMap = (Tutorial_TileMap)target;
            tileMap.DiscardMap();

            EditorUtility.SetDirty(tileMap);
        }
    }
}
