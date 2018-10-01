using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Manager_BaseCamp : MonoBehaviour
{
    public GameObject buttonCharacters;
    //public GameObject buttonOrganizeTeam;

    private bool windowOpened = false;

    public void OpenCharacters()
    {
        if (windowOpened == true) return;

        this.GetComponent<Player_Characters>().OpenCharacters();

        windowOpened = true;

        DisableButtons();
    }

    public void CloseCharacters(bool editor = false)
    {
        if (windowOpened == false) return;

        this.GetComponent<Player_Characters>().CloseCharacters(editor);

        windowOpened = false;

        EnableButtons();
    }

    public void OpenOrganizeTeam()
    {
        if (windowOpened == true) return;

        this.GetComponent<Player_OrganizeTeam>().OpenOrganizeTeam();

        windowOpened = true;

        DisableButtons();
    }

    public void CloseOrganizeTeam(bool editor = false)
    {
        if (windowOpened == false) return;

        this.GetComponent<Player_OrganizeTeam>().CloseOrganizeTeam(editor);

        windowOpened = false;

        EnableButtons();
    }

    private void EnableButtons()
    {
        buttonCharacters.gameObject.SetActive(true);
        //buttonOrganizeTeam.gameObject.SetActive(true);
    }

    private void DisableButtons()
    {
        buttonCharacters.gameObject.SetActive(false);
        //buttonOrganizeTeam.gameObject.SetActive(false);
    }
}
