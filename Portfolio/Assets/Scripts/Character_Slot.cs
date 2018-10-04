using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

namespace Player
{
    public class Character_Slot : MonoBehaviour
    {
        public Player_Main playerMain;
        public GameObject checkImage;
        public GameObject highlightedFrame;

        public delegate void Delegate_SelectCharacter(Character_Slot selectedSlot);
        public Delegate_SelectCharacter SelectCharacterCallback;

        private Character_Base character = null;

        public Character_Base CorrespondingCharacter { get { return character; } }
        public bool TeamFellow { get; private set; }

        public void SetCharacterAddedAsTeam(bool flag)
        {
            if (flag == true)
            {
                highlightedFrame.gameObject.SetActive(false);
                this.gameObject.GetComponent<Image>().color = Color.gray;
                checkImage.gameObject.SetActive(true);
                TeamFellow = true;
            }
            else
            {
                highlightedFrame.gameObject.SetActive(false);
                this.gameObject.GetComponent<Image>().color = Color.white;
                checkImage.gameObject.SetActive(false);
                TeamFellow = false;
            }
        }

        public void SelectCharacter()
        {
            SelectCharacterCallback(this);

            //highlightedFrame.gameObject.SetActive(true);
        }

        public void Initialize(Character_Base correspondingCharacter, Delegate_SelectCharacter selectCharacter)
        {
            this.character = correspondingCharacter;

            SetPortrait();

            SelectCharacterCallback = selectCharacter;

            TeamFellow = false;
        }

        //private bool TeamFellow()
        //{
        //    for (int i = 0; i < playerMain.playerTeam.teamFellow.Length; i++)
        //    {
        //        if (this.character == playerMain.playerTeam.teamFellow[i]) return true;
        //    }

        //    return false;
        //}

        private void SetPortrait()
        {
            for (int i = 0; i < playerMain.characterDatabase.Portraits.Count; i++)
            {
                if (character.TypeID == playerMain.characterDatabase.Portraits[i].typeID)
                {
                    this.GetComponent<Image>().sprite = playerMain.characterDatabase.Portraits[i].image;
                    break;
                }
            }
        }
    }
}
