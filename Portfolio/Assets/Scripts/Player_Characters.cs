using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

namespace Player
{
    public class Player_Characters : MonoBehaviour
    {
        public Player_Main playerMain;
        public Character_Database characterDatabase;

        public GameObject charactersPanel;
        public GameObject slotField;
        public GameObject strength;
        public GameObject agility;
        public GameObject intelligence;
        public GameObject slotPrefab;

        public GameObject charactersButton;

        private List<GameObject> characters = new List<GameObject>();
        private readonly string stringStrength = "Strength : ";
        private readonly string stringAgility = "Agility : ";
        private readonly string stringIntelligence = "Intelligence : ";

        public void SelectCharacter(Character_Base selectedCharacter)
        {
            if (charactersPanel.activeSelf == false) return;

            //if (IndexOutOfRange(characterIndex, characters) == true)
            //{
            //    DisableStrings();
            //    return;
            //}

            EnableStrings();

            //Character_Base selectedCharacter = playerMain.Characters[characterIndex];

            strength.GetComponent<Text>().text = stringStrength + selectedCharacter.Strength.ToString();
            agility.GetComponent<Text>().text = stringAgility + selectedCharacter.Agility.ToString();
            intelligence.GetComponent<Text>().text = stringIntelligence + selectedCharacter.Intelligence.ToString();
        }

        public void OpenCharacters()
        {
            charactersPanel.SetActive(true);

            for (int i = 0; i < playerMain.Characters.Count; i++)
            {
                GameObject addedSlot = Instantiate<GameObject>(slotPrefab, slotField.transform);
                addedSlot.GetComponent<Character_Slot>().Initialize(playerMain.Characters[i], SelectCharacter);

                characters.Add(addedSlot);
            }

            charactersButton.SetActive(false);
        }

        public void CloseCharacters(bool editor = false)
        {
            ResetStrings();
            DisableStrings();

            if (editor == true)
            {
                for (int i = characters.Count - 1; i >= 0; i--)
                {
                    DestroyImmediate(characters[i].gameObject);
                }
            }
            else
            {
                for (int i = characters.Count - 1; i >= 0; i--)
                {
                    Destroy(characters[i].gameObject);
                }
            }

            characters.Clear();

            charactersPanel.SetActive(false);

            charactersButton.SetActive(true);
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

        // editor
        public int selectedCharacterIndex;

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

            strength.GetComponent<Text>().text = stringStrength + selectedCharacter.Strength.ToString();
            agility.GetComponent<Text>().text = stringAgility + selectedCharacter.Agility.ToString();
            intelligence.GetComponent<Text>().text = stringIntelligence + selectedCharacter.Intelligence.ToString();
        }
    }
}
