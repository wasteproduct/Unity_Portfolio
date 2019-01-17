using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    public class UI_Window_PlayerCharacters : UI_Window_Base
    {
        [SerializeField]
        private Player_Main playerMain;
        [SerializeField]
        private UI_CharacterStatus characterStatus;
        [SerializeField]
        private UI_CharacterSlot[] characterSlots;

        public void SelectSlot()
        {
            for (int i = 0; i < characterSlots.Length; i++)
            {
                if (characterSlots[i].gameObject.activeSelf == false) continue;

                characterSlots[i].HighlightSlot(false);

                if (characterSlots[i].SlotCharacter.InstantiatedModel == null) continue;
                characterSlots[i].SlotCharacter.InstantiatedModel.gameObject.SetActive(false);
            }
        }

        public void Editor_GetSlots()
        {
            UI_CharacterSlot[] slots = GetComponentsInChildren<UI_CharacterSlot>(true);

            for (int i = 0; i < slots.Length; i++)
            {
                characterSlots[i] = slots[i];
            }
        }

        private void OnEnable()
        {
            List<Character_Base> playerCharacters = playerMain.Characters;

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                characterSlots[i].gameObject.SetActive(true);
                characterSlots[i].SetSlot(playerCharacters[i]);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < characterSlots.Length; i++)
            {
                characterSlots[i].HighlightSlot(false);
                characterSlots[i].gameObject.SetActive(false);
            }

            characterStatus.ClearValues();

            for (int i = 0; i < playerMain.Characters.Count; i++)
            {
                playerMain.Characters[i].InstantiatedModel.gameObject.SetActive(false);
            }
        }
    }
}
