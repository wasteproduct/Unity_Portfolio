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
        public Player_Team playerTeam;

        [SerializeField]
        private List<Character_Base> characters = new List<Character_Base>();

        public List<Character_Base> Characters { get { return characters; } }

        public void AddNewCharacter(Character_Base newCharacter)
        {
            if (characters.Contains(newCharacter) == false) characters.Add(newCharacter);
        }

        private void OnEnable()
        {
            LoadData();
        }

        // Editor
        public int listIndex;
        public Character_Base addedCharacterBase;

        public void AddCharacter()
        {
            LoadData();

            Character_Base newCharacter = ScriptableObject.CreateInstance<Character_Base>();
            newCharacter.Name = addedCharacterBase.Name;
            newCharacter.TypeID = addedCharacterBase.TypeID;
            newCharacter.Strength = addedCharacterBase.Strength;
            newCharacter.Agility = addedCharacterBase.Agility;
            newCharacter.Intelligence = addedCharacterBase.Intelligence;

            characters.Add(newCharacter);

            SaveData();
        }

        public void ClearList()
        {
            ClearCharacters();

            SaveData();
        }

        public void LoadData()
        {
            string playerDataJSON = File.ReadAllText(Application.streamingAssetsPath + "/Editor_PlayerData.json");

            Editor_PlayerData playerData = JsonUtility.FromJson<Editor_PlayerData>(playerDataJSON);

            ClearCharacters();

            for (int i = 0; i < playerData.Characters.Length; i++)
            {
                Character_Base newCharacter = CreateInstance<Character_Base>();
                newCharacter.CopyData(playerData.Characters[i]);

                characters.Add(newCharacter);
            }
        }

        public void SaveData()
        {
            string playerDataJSON = File.ReadAllText(Application.streamingAssetsPath + "/Editor_PlayerData.json");

            Editor_PlayerData playerData = JsonUtility.FromJson<Editor_PlayerData>(playerDataJSON);

            List<Editor_CharacterData> newCharacters = new List<Editor_CharacterData>();
            for (int i = 0; i < characters.Count; i++)
            {
                Editor_CharacterData newCharacter = new Editor_CharacterData(characters[i]);

                newCharacters.Add(newCharacter);
            }

            playerData.Characters = newCharacters.ToArray();

            playerDataJSON = JsonUtility.ToJson(playerData);

            File.WriteAllText(Application.streamingAssetsPath + "/Editor_PlayerData.json", playerDataJSON);
        }

        public void IncreaseStrength()
        {
            if (characters.Count <= 0) return;

            if ((listIndex < 0) || (listIndex >= characters.Count)) return;

            characters[listIndex].Strength++;

            SaveData();
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

    [System.Serializable]
    public class Editor_PlayerData
    {
        public Editor_CharacterData[] Characters;
    }

    [System.Serializable]
    public class Editor_CharacterData
    {
        public string Name;
        public int TypeID;
        public int Strength;
        public int Agility;
        public int Intelligence;

        public Editor_CharacterData(Character_Base character)
        {
            this.Name = character.Name;
            this.TypeID = character.TypeID;
            this.Strength = character.Strength;
            this.Agility = character.Agility;
            this.Intelligence = character.Intelligence;
        }
    }
}
