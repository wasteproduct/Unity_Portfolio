using UnityEngine;
using UnityEngine.UI;

public class Button_Close : MonoBehaviour
{
    [SerializeField]
    private GameObject closedWindow;
    [SerializeField]
    private Text buttonText;
    [SerializeField]
    private GameObject[] reactivatedObject;

    public void SetButtonText(string text) { buttonText.text = text; }

    public void Close()
    {
        closedWindow.gameObject.SetActive(false);

        for (int i = 0; i < reactivatedObject.Length; i++)
        {
            reactivatedObject[i].gameObject.SetActive(true);
        }
    }
}
