using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Team", order = 1)]
    public class Player_Team : ScriptableObject
    {
        [SerializeField]
        private Character_Base captain;
        [SerializeField]
        private Character_Base[] teamFellow;

        public Variable_Int currentTileX;
        public Variable_Int currentTileZ;

        public Character_Base Captain { get { return captain; } }
        public Character_Base[] TeamFellows { get { return teamFellow; } }

        public void SetTeam(UI_TeamSlot[] teamSlots)
        {
            captain = teamSlots[0].RegisteredCharacterSlot.SlotCharacter;

            List<UI_CharacterSlot_ComposingTeam> characterSlots = new List<UI_CharacterSlot_ComposingTeam>();

            for (int i = 1; i < teamSlots.Length; i++)
            {
                characterSlots.Add(teamSlots[i].RegisteredCharacterSlot);
            }

            for (int i = 0; i < teamFellow.Length; i++)
            {
                teamFellow[i] = (characterSlots[i] == null) ? null : characterSlots[i].SlotCharacter;
            }
        }
    }
}
