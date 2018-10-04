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

        private Character_Base selectedCharacter = null;

        public void Initialize()
        {
            this.GetComponent<Image>().sprite = slotSprite;
            selectedCharacter = null;
        }

        public void SetSelectedCharacter(Character_Base pickedCharacter)
        {
            selectedCharacter = pickedCharacter;
        }

        public void AddTeamFellow()
        {

            //AddTeamFellowCallback(selectedCharacter, slotIndex);
            //for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            //{
            //    if (selectedCharacter.TypeID == characterDatabase.Portraits[i].typeID)
            //    {
            //        this.GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
            //        break;
            //    }
            //}
        }
    }
}
