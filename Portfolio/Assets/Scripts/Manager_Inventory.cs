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
    private Image[] slot;

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
        print(inventory.Items.Count);

        for (int i = 0; i < inventory.Items.Count; i++)
        {
            slot[i].sprite = inventory.Items[i].ItemImage;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].sprite = null;
        }

        interactingUI.flag = false;
    }
}
