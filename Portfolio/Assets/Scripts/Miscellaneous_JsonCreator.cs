using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Miscellaneous_JsonCreator : MonoBehaviour
{
    public string fileName;
    /*public void SaveData()
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
        }*/
    public void Save()
    {
        //string skillData = File.ReadAllText(Application.streamingAssetsPath + "/" + fileName + ".json");
    }
}
