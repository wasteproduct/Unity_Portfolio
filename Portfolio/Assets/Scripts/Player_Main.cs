using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    public class Player_Main : ScriptableObject
    {
        private List<Character_Base> characters = new List<Character_Base>();

        public List<Character_Base> Characters { get { return characters; } }

        public void AddNewCharacter(Character_Base newCharacter)
        {
            if (characters.Contains(newCharacter) == false) characters.Add(newCharacter);
        }

        private void OnDisable()
        {
            for (int i = characters.Count - 1; i >= 0; i--)
            {
                characters.RemoveAt(i);
            }

            characters.Clear();
        }
    }
}
