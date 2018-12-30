using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_DungeonUI : MonoBehaviour
{
    [SerializeField]
    private Event_Click clickEvent;
    [SerializeField]
    private GameObject openedWindow;

    public void ButtonWork()
    {
        clickEvent.uIClicked = true;
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
