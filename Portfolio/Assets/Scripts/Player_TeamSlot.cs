using UnityEngine;
using Character;
using UnityEngine.UI;

namespace Player
{
    public class Player_TeamSlot : MonoBehaviour
    {
        public Character_Database characterDatabase;
        public GameObject highlightedFrame;
        public Sprite slotSprite;
        public int slotIndex;

        public delegate void Delegate_AddTeamFellow(Character_Base selectedCharacter, int slotIndex);
        public Delegate_AddTeamFellow AddTeamFellowCallback;

        private Character_Base selectedCharacter = null;

        public void SetSelectedCharacter(Character_Base pickedCharacter)
        {
            selectedCharacter = pickedCharacter;
        }

        public void AddTeamFellow()
        {
            AddTeamFellowCallback(selectedCharacter, slotIndex);
            for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            {
                if (selectedCharacter.TypeID == characterDatabase.Portraits[i].typeID)
                {
                    this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                    break;
                }
            }
        }

        public void Initialize(Character_Base occupyingCharacter, Delegate_AddTeamFellow cancelSelection)
        {
            AddTeamFellowCallback = cancelSelection;

            if (occupyingCharacter == null)
            {
                this.GetComponent<Image>().sprite = slotSprite;
            }
            else
            {
                for (int i = 0; i < characterDatabase.Portraits.Count; i++)
                {
                    if (occupyingCharacter.TypeID == characterDatabase.Portraits[i].typeID)
                    {
                        this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                        break;
                    }
                }
            }
        }
    }
}
