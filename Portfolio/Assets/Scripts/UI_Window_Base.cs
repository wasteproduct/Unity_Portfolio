using UnityEngine;

public abstract class UI_Window_Base : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] reactivatedObject;

    protected void OnDisable()
    {
        for (int i = 0; i < reactivatedObject.Length; i++)
        {
            reactivatedObject[i].gameObject.SetActive(true);
        }
    }
}
