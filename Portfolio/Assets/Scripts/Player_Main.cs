using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Main", order = 1)]
    public class Player_Main : ScriptableObject
    {
        public Character_Base soldierBase;
        public Character_Base tankBase;

        private List<Character_Base> characters = new List<Character_Base>();

        public List<Character_Base> Characters { get { return characters; } }

        public void AddNewCharacter(Character_Base newCharacter)
        {
            if (characters.Contains(newCharacter) == false) characters.Add(newCharacter);
        }


        // temporary
        // 여기
        public int listIndex;

        public void PrintCharacterInformation()
        {

        }

        public void IncreaseStrength()
        {

        }

        public void AddCharacters()
        {
            Character_Base newSoldier = ScriptableObject.CreateInstance<Character_Base>();
            newSoldier = soldierBase;

            Character_Base newTank = ScriptableObject.CreateInstance<Character_Base>();
            newTank = tankBase;

            characters.Add(newSoldier);
            characters.Add(newTank);
        }
        
        public void ClearCharacters()
        {
            for (int i = characters.Count - 1; i >= 0; i--)
            {
                characters.RemoveAt(i);
            }

            characters.Clear();
        }
    }
}
