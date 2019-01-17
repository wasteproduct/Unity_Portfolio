using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Character;

public class Manager_BaseCamp2 : MonoBehaviour
{
    [SerializeField]
    private Player_Main playerMain;
    [SerializeField]
    private Player_Team playerTeam;

    public void ToDungeon(UI_Window_ComposeTeam teamComposer)
    {
        playerTeam.SetTeam(teamComposer.TeamSlots);
    }

    // Use this for initialization
    void Start()
    {
        List<Character_Base> playerCharacters = playerMain.Characters;

        for (int i = 0; i < playerCharacters.Count; i++)
        {
            if (playerCharacters[i].DisplayedModel == null) continue;

            playerCharacters[i].InstantiatedModel = Instantiate(playerCharacters[i].DisplayedModel);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
