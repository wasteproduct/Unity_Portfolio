using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

namespace Player
{
    public class Character_Slot : MonoBehaviour
    {
        public Character_Database characterDatabase;

        public delegate void Delegate_SelectCharacter(Character_Base selectedCharacter);
        public Delegate_SelectCharacter selectCharacterCallback;

        private Character_Base character;

        public void SelectCharacter()
        {
            selectCharacterCallback(this.character);
        }

        public void Initialize(Character_Base correspondingCharacter, Delegate_SelectCharacter selectCharacter)
        {
            this.character = correspondingCharacter;

            SetPortrait();

            selectCharacterCallback = selectCharacter;
        }

        private void SetPortrait()
        {
            for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            {
                if (character.TypeID == characterDatabase.Portraits[i].typeID)
                {
                    this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                    break;
                }
            }
        }
    }
}
