using UnityEngine;
using Player;
using UnityEngine.SceneManagement;

public class Manager_BaseCamp : MonoBehaviour
{
    public Player_Team playerTeam;
    public GameObject buttonCharacters;
    //public GameObject buttonOrganizeTeam;
    public GameObject buttonToDungeon;

    private bool windowOpened = false;

    public void EnterDungeon()
    {
        Player_ToDungeon toDungeon = this.GetComponent<Player_ToDungeon>();

        playerTeam.captain = toDungeon.slotCaptain.GetComponent<Player_TeamSlot>().AddedTeamFellowSlot.CorrespondingCharacter;
        for (int i = 0; i < toDungeon.slotFellow.Length; i++)
        {
            if (toDungeon.slotFellow[i].GetComponent<Player_TeamSlot>().AddedTeamFellowSlot == null) continue;

            playerTeam.teamFellow[i] = toDungeon.slotFellow[i].GetComponent<Player_TeamSlot>().AddedTeamFellowSlot.CorrespondingCharacter;
        }

        SceneManager.LoadScene("Scene_Dungeon");
    }

    public void SelectTeamFellows()
    {
        if (windowOpened == true) return;

        this.GetComponent<Player_ToDungeon>().OpenSelectTeamFellows();

        windowOpened = true;

        DisableButtons();

        // 진행 버튼은 선택된 팀원 리스트에 담긴 데이터 json으로 저장, 다음 신 던전으로 진행

        // 팀원 리스트에 담을 형식은 Editor_CharacterData

        // 신 넘어가면 json에 담긴 리스트 읽어서 인 던전 플레이어 캐릭터 팀에 로드
    }

    public void CancelSelectTeamFellows(bool editor = false)
    {
        if (windowOpened == false) return;

        this.GetComponent<Player_ToDungeon>().CancelSelectTeamFellows(editor);

        windowOpened = false;

        EnableButtons();
    }

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

    private void EnableButtons()
    {
        buttonCharacters.gameObject.SetActive(true);
        //buttonOrganizeTeam.gameObject.SetActive(true);
        buttonToDungeon.gameObject.SetActive(true);
    }

    private void DisableButtons()
    {
        buttonCharacters.gameObject.SetActive(false);
        //buttonOrganizeTeam.gameObject.SetActive(false);
        buttonToDungeon.gameObject.SetActive(false);
    }

    //public void OpenOrganizeTeam()
    //{
    //    if (windowOpened == true) return;

    //    this.GetComponent<Player_OrganizeTeam>().OpenOrganizeTeam();

    //    windowOpened = true;

    //    DisableButtons();
    //}

    //public void CloseOrganizeTeam(bool editor = false)
    //{
    //    if (windowOpened == false) return;

    //    this.GetComponent<Player_OrganizeTeam>().CloseOrganizeTeam(editor);

    //    windowOpened = false;

    //    EnableButtons();
    //}
}
