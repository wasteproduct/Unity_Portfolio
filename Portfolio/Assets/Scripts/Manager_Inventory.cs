using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class Manager_Inventory : MonoBehaviour
{
    [SerializeField]
    private Player_Inventory inventory;
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private GameObject[] slot;

    public void Editor_GetSlots()
    {
        //find
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            slot[i].GetComponent<Button_InventorySlot>().SetButton(inventory.Items[i]);
        }
    }

    private void OnDisable()
    {
        interactingUI.flag = false;
    }
}
