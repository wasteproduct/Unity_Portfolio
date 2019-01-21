using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_TileMap_2))]
public class Inspector_Tutorial_TileMap2 : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Map"))
        {
            Tutorial_TileMap_2 tileMap = (Tutorial_TileMap_2)target;
            tileMap.GenerateMap();

            EditorUtility.SetDirty(tileMap);
        }

        if (GUILayout.Button("Discard Map"))
        {
            Tutorial_TileMap_2 tileMap = (Tutorial_TileMap_2)target;
            tileMap.DiscardMap();

            EditorUtility.SetDirty(tileMap);
        }
    }
}
