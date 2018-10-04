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

        public delegate void Delegate_AddTeamFellow();

        private Character_Slot selectedSlot = null;

        private Delegate_AddTeamFellow AddTeamFellowCallback;

        public Character_Slot AddedTeamFellowSlot { get; private set; }

        public void Initialize(Delegate_AddTeamFellow addTeamFellow)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().sprite = slotSprite;
            selectedSlot = null;
            AddedTeamFellowSlot = null;

            AddTeamFellowCallback = addTeamFellow;
        }

        public void Initialize()
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().sprite = slotSprite;
            selectedSlot = null;
            AddedTeamFellowSlot = null;
        }

        public void SetSelectedSlot(Character_Slot pickedSlot)
        {
            this.GetComponent<Button>().interactable = true;
            selectedSlot = pickedSlot;
        }

        public void AddTeamFellow()
        {
            bool switching = (AddedTeamFellowSlot == null) ? false : true;

            if (switching == true)
            {
                AddedTeamFellowSlot.SetCharacterAddedAsTeam(false);
            }

            AddedTeamFellowSlot = selectedSlot.GetComponent<Character_Slot>();

            //print("Added");

            AddTeamFellowCallback();

            for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            {
                if (AddedTeamFellowSlot.CorrespondingCharacter.TypeID == characterDatabase.Portraits[i].typeID)
                {
                    this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                    return;
                }
            }
        }
    }
}
