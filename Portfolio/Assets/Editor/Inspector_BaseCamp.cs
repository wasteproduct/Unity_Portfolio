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
            baseCamp.OpenCharacters();

            EditorUtility.SetDirty(baseCamp);
        }

        if (GUILayout.Button("Close Characters"))
        {
            Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;
            baseCamp.CloseCharacters(true);

            EditorUtility.SetDirty(baseCamp);
        }

        if (GUILayout.Button("To Dungeon"))
        {
            Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;
            baseCamp.ToDungeon();

            EditorUtility.SetDirty(baseCamp);
        }

        if (GUILayout.Button("Cancel"))
        {
            Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;
            baseCamp.Cancel(true);

            EditorUtility.SetDirty(baseCamp);
        }

        //if (GUILayout.Button("Open Organize Team"))
        //{
        //    Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;
        //    baseCamp.OpenOrganizeTeam();

        //    EditorUtility.SetDirty(baseCamp);
        //}

        //if (GUILayout.Button("Close Organize Team"))
        //{
        //    Manager_BaseCamp baseCamp = (Manager_BaseCamp)target;
        //    baseCamp.CloseOrganizeTeam(true);

        //    EditorUtility.SetDirty(baseCamp);
        //}
    }
}
