using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using System.IO;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Main", order = 1)]
    public class Player_Main : ScriptableObject
    {
        public Character_Database characterDatabase;

        [SerializeField]
        private List<Character_Base> characters = new List<Character_Base>();

        public List<Character_Base> Characters { get { return characters; } }

        public void AddNewCharacter(Character_Base newCharacter)
        {
            if (characters.Contains(newCharacter) == false) characters.Add(newCharacter);
        }


        // Editor
        public int listIndex;
        public Character_Base addedCharacterBase;

        public void AddCharacter()
        {
            Character_Base newCharacter = ScriptableObject.CreateInstance<Character_Base>();
            newCharacter.CopyData(addedCharacterBase);

            characters.Add(newCharacter);
        }

        public void Refresh()
        {
            ClearCharacters();


        }

        public void PrintCharacterInformation()
        {
            if (characters.Count <= 0) return;

            if ((listIndex < 0) || (listIndex >= characters.Count)) return;

            Debug.Log("Name : " + characters[listIndex].characterName);
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
