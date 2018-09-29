using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tutorial
{
    public class Tutorial_StreamingAsset : MonoBehaviour
    {
        public void WriteJSON()
        {
            string jsonString = File.ReadAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json");

            Jason jason = JsonUtility.FromJson<Jason>(jsonString);

            string jasonInformation = jsonString;

            jason.Characters = null;

            jasonInformation = JsonUtility.ToJson(jason);

            File.WriteAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json", jasonInformation);

            Debug.Log(jasonInformation);
        }

        public void AddCharacter()
        {
            string jsonString = File.ReadAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json");

            Jason jason = JsonUtility.FromJson<Jason>(jsonString);

            string jasonInformation = jsonString;

            List<Tutorial_Character> characters = new List<Tutorial_Character>();
            for (int i = 0; i < jason.Characters.Length; i++)
            {
                characters.Add(jason.Characters[i]);
            }

            Tutorial_Character newCharacter = new Tutorial_Character("hellfire", 1, 10, 100);
            characters.Add(newCharacter);

            jason.Characters = characters.ToArray();

            jasonInformation = JsonUtility.ToJson(jason);

            File.WriteAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json", jasonInformation);

            Debug.Log(jasonInformation);
        }
    }

    [System.Serializable]
    public class Jason
    {
        public Tutorial_Character[] Characters;
    }

    [System.Serializable]
    public class Tutorial_Character
    {
        public Tutorial_Character(string name, int strength, int agility, int intelligence)
        {
            Name = name;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }

        public string Name;
        public int Strength;
        public int Agility;
        public int Intelligence;
    }
}
