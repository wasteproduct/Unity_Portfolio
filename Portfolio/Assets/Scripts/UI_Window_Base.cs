using UnityEngine;

public abstract class UI_Window_Base : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] reactivatedObjects;

    protected abstract void CustomOnDisable();

    protected void OnDisable()
    {
        for (int i = 0; i < reactivatedObjects.Length; i++)
        {
            reactivatedObjects[i].gameObject.SetActive(true);
        }

        CustomOnDisable();
    }
}
