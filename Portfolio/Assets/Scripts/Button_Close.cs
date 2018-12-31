using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Close : MonoBehaviour
{
    [SerializeField]
    private GameObject closedWindow;
    [SerializeField]
    private GameObject[] reactivatedObject;

    public void Close()
    {
        closedWindow.gameObject.SetActive(false);

        for (int i = 0; i < reactivatedObject.Length; i++)
        {
            reactivatedObject[i].gameObject.SetActive(true);
        }
    }
}
