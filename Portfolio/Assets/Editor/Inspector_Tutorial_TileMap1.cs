using UnityEngine;
using UnityEditor;
using Tutorial;

[CustomEditor(typeof(Tutorial_TileMap_1))]
public class Inspector_Tutorial_TileMap1 : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Map"))
        {
            Tutorial_TileMap_1 tileMap = (Tutorial_TileMap_1)target;
            tileMap.GenerateMap();

            EditorUtility.SetDirty(tileMap);
        }

        if (GUILayout.Button("Discard Map"))
        {
            Tutorial_TileMap_1 tileMap = (Tutorial_TileMap_1)target;
            tileMap.DiscardMap();

            EditorUtility.SetDirty(tileMap);
        }
    }
}
