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

        if (buttons != null) buttons.gameObject.SetActive(false);
        if (openedWindow != null) openedWindow.gameObject.SetActive(true);
    }
}
