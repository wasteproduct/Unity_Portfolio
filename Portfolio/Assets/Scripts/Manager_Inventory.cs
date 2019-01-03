using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Manager_Inventory : MonoBehaviour
{
    [SerializeField]
    private Player_Inventory inventory;
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private Player_InDungeonManager playerManager;
    [SerializeField]
    private Button_InventorySlot[] slot;

    public void SelectItem()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].HighlightItem(false);
        }
    }

    public void Editor_GetSlots()
    {
        Button_InventorySlot[] slots = GetComponentsInChildren<Button_InventorySlot>();

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = slots[i];
        }
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
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].Initialize();
        }

        for (int i = 0; i < inventory.Items.Count; i++)
        {
            slot[i].SetButton(inventory.Items[i]);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].HighlightItem(false);
        }
        playerManager.DisableAll();

        interactingUI.flag = false;
    }
}
