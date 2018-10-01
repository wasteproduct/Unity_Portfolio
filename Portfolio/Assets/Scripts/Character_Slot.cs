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

        public delegate void Delegate_SelectCharacter(Character_Base selectedCharacter);
        public Delegate_SelectCharacter SelectCharacterCallback;

        private Character_Base character = null;

        public void SelectCharacter()
        {
            SelectCharacterCallback(this.character);

            highlightedFrame.gameObject.SetActive(true);
        }

        public void Initialize(Character_Base correspondingCharacter, Delegate_SelectCharacter selectCharacter)
        {
            this.character = correspondingCharacter;

            SetPortrait();

            SelectCharacterCallback = selectCharacter;

            bool teamFellow = TeamFellow();
            if (teamFellow == true) print("Hey");
        }

        private bool TeamFellow()
        {
            for (int i = 0; i < playerMain.playerTeam.teamFellow.Length; i++)
            {
                if (this.character == playerMain.playerTeam.teamFellow[i]) return true;
            }

            return false;
        }

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
