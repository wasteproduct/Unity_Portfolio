using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button_SwitchScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private string confirmedContents;
    [SerializeField]
    private UI_Confirmer confirmer;

    public void OpenConfirmer()
    {
        confirmer.gameObject.SetActive(true);
        confirmer.SetVoidMethod(SwitchScene);
        confirmer.SetConfirmedContents(confirmedContents);
    }

    public void SwitchScene() { SceneManager.LoadScene(sceneName); }
}
