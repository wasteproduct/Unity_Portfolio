﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NoticingWindow : MonoBehaviour
{
    [SerializeField]
    private Event_GetItem eventGetItem;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Text itemDescription;

    public void ShowNewItem()
    {
        itemImage.sprite = eventGetItem.NewItem.ItemImage;
        itemName.text = eventGetItem.NewItem.ItemName;
        itemDescription.text = eventGetItem.NewItem.ItemDescription;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
