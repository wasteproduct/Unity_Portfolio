using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

namespace Player
{
    public class Player_Characters : MonoBehaviour
    {
        public Player_Main playerMain;

        public GameObject charactersPanel;
        public GameObject slotField;
        public GameObject strength;
        public GameObject agility;
        public GameObject intelligence;
        public GameObject slotPrefab;
        public int selectedCharacterIndex;

        private List<GameObject> characters = new List<GameObject>();
        private readonly string stringStrength = "Strength : ";
        private readonly string stringAgility = "Agility : ";
        private readonly string stringIntelligence = "Intelligence : ";

        public void SelectCharacter()
        {
            if (charactersPanel.activeSelf == false) return;

            if (IndexOutOfRange(selectedCharacterIndex, characters) == true)
            {
                DisableStrings();
                return;
            }

            EnableStrings();

            Character_Base selectedCharacter = playerMain.Characters[selectedCharacterIndex];

            strength.GetComponent<Text>().text = stringStrength + selectedCharacter.strength.ToString();
            agility.GetComponent<Text>().text = stringAgility + selectedCharacter.agility.ToString();
            intelligence.GetComponent<Text>().text = stringIntelligence + selectedCharacter.intelligence.ToString();
        }

        public void OpenCharacters()
        {
            charactersPanel.SetActive(true);

            for (int i = 0; i < playerMain.Characters.Count; i++)
            {
                GameObject addedSlot = Instantiate<GameObject>(slotPrefab, slotField.transform);
                addedSlot.GetComponent<Image>().sprite = playerMain.Characters[i].portrait;

                characters.Add(addedSlot);
            }
        }

        public void CloseCharacters()
        {
            ResetStrings();
            DisableStrings();

            charactersPanel.SetActive(false);

            for (int i = characters.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(characters[i].gameObject);
            }

            characters.Clear();
        }

        private void EnableStrings()
        {
            strength.SetActive(true);
            agility.SetActive(true);
            intelligence.SetActive(true);
        }

        private void DisableStrings()
        {
            strength.SetActive(false);
            agility.SetActive(false);
            intelligence.SetActive(false);
        }

        private void ResetStrings()
        {
            strength.GetComponent<Text>().text = stringStrength;
            agility.GetComponent<Text>().text = stringAgility;
            intelligence.GetComponent<Text>().text = stringIntelligence;
        }

        private bool IndexOutOfRange(int index, List<GameObject> list)
        {
            if (index < 0) return true;
            if (index >= list.Count) return true;

            return false;
        }
    }
}
