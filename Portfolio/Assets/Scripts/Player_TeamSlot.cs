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

        public delegate void Delegate_InactivateTeamSlots();

        private Character_Base selectedCharacter = null;
        private Character_Base addedTeamFellow = null;

        private Delegate_InactivateTeamSlots ActivateTeamSlots;

        public void Initialize(Delegate_InactivateTeamSlots activateTeamSlots)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().sprite = slotSprite;
            selectedCharacter = null;
            addedTeamFellow = null;

            ActivateTeamSlots = activateTeamSlots;
        }

        public void SetSelectedCharacter(Character_Base pickedCharacter)
        {
            this.GetComponent<Button>().interactable = true;
            selectedCharacter = pickedCharacter;
        }

        public void AddTeamFellow()
        {
            addedTeamFellow = selectedCharacter;

            for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            {
                if (addedTeamFellow.TypeID == characterDatabase.Portraits[i].typeID)
                {
                    this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                    return;
                }
            }

            print("Added");

            ActivateTeamSlots();
        }
    }
}
