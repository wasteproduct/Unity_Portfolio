using UnityEngine;
using Player;

public class Manager_BaseCamp : MonoBehaviour
{
    public GameObject buttonCharacters;
    //public GameObject buttonOrganizeTeam;
    public GameObject buttonToDungeon;

    private bool windowOpened = false;

    public void ToDungeon()
    {
        if (windowOpened == true) return;

        this.GetComponent<Player_ToDungeon>().OpenSelectTeamFellows();

        windowOpened = true;

        DisableButtons();

        // 팀 편성 창과 비슷한 창 팀원 선택 창 만들고 띄워서

        // 닫기와 진행 버튼 2개

        // 닫기는 그냥 바로 닫음

        // 진행 버튼은 선택된 팀원 리스트에 담긴 데이터 json으로 저장, 다음 신 던전으로 진행

        // 팀원 리스트에 담을 형식은 Editor_CharacterData

        // 신 넘어가면 json에 담긴 리스트 읽어서 인 던전 플레이어 캐릭터 팀에 로드
    }

    public void Cancel(bool editor = false)
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
