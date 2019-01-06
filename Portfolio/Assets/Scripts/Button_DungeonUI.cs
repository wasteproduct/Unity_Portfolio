using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_DungeonUI : MonoBehaviour
{
    [SerializeField]
    private Event_Click clickEvent;
    [SerializeField]
    private GameObject openedWindow;
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private Variable_Bool cursorDisabled;
    [SerializeField]
    private GameObject buttons;

    public void ButtonWork()
    {
        clickEvent.uIClicked = true;
        interactingUI.flag = true;
        cursorDisabled.flag = true;

        buttons.gameObject.SetActive(false);
        openedWindow.gameObject.SetActive(true);
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
