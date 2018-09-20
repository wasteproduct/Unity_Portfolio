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
        public int listIndex;

        public void PrintCharacterInformation()
        {
            if (characters.Count <= 0) return;

            if ((listIndex < 0) || (listIndex >= characters.Count)) return;

            Debug.Log("Name : " + characters[listIndex].characterName);
            Debug.Log("Type : " + characters[listIndex].type);
            Debug.Log("Strength : " + characters[listIndex].strength);
            Debug.Log("Agility : " + characters[listIndex].agility);
            Debug.Log("Intelligence : " + characters[listIndex].intelligence);
        }

        public void IncreaseStrength()
        {
            if (characters.Count <= 0) return;

            if ((listIndex < 0) || (listIndex >= characters.Count)) return;

            characters[listIndex].strength++;
        }

        public void AddCharacters()
        {
            Character_Base newSoldier = ScriptableObject.CreateInstance<Character_Base>();
            newSoldier.CopyData(soldierBase);

            Character_Base newTank = ScriptableObject.CreateInstance<Character_Base>();
            newTank.CopyData(tankBase);

            characters.Add(newSoldier);
            characters.Add(newTank);

            Debug.Log(characters.Count);
        }
        
        public void ClearCharacters()
        {
            if (characters.Count <= 0) return;

            for (int i = characters.Count - 1; i >= 0; i--)
            {
                characters.RemoveAt(i);
            }

            characters.Clear();
        }
    }
}
