using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button_OpenWindow : MonoBehaviour
{
    [SerializeField]
    private UI_Window_Base openedWindow;
    [SerializeField]
    private GameObject[] disabledObject;

    public void OpenWindow()
    {
        openedWindow.gameObject.SetActive(true);

        for (int i = 0; i < disabledObject.Length; i++)
        {
            disabledObject[i].gameObject.SetActive(false);
        }
    }
}
