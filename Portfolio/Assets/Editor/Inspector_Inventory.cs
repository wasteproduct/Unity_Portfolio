using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Manager_Inventory))]
public class Inspector_Inventory : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        if (GUILayout.Button("Get Slots"))
        {
            Manager_Inventory inventory = (Manager_Inventory)target;
            inventory.Editor_GetSlots();

            EditorUtility.SetDirty(inventory);
        }
    }
}
