using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class UI_Window_PlayerCharacters : UI_Window_Base
    {
        [SerializeField]
        private Player_Main playerMain;
        [SerializeField]
        private UI_CharacterSlot[] characterSlot;

        public void Editor_GetSlots()
        {
            UI_CharacterSlot[] slots = GetComponentsInChildren<UI_CharacterSlot>();

            for (int i = 0; i < slots.Length; i++)
            {
                characterSlot[i] = slots[i];
            }
        }

        private void OnEnable()
        {
            
        }
    }
}
