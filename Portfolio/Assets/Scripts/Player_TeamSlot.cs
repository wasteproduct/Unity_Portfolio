using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

namespace Player
{
    public class Player_TeamSlot : MonoBehaviour
    {
        public Character_Database characterDatabase;
        public GameObject highlightedFrame;

        public void Initialize(Character_Base occupyingCharacter)
        {
            if (occupyingCharacter == null)
            {

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

        // 여기
        public void AddTeamFellow()
        {

        }
    }
}
