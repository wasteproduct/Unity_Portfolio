using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

namespace Player
{
    public class Player_Move : MonoBehaviour
    {
        public Calculation_Move moveController;
        public Event_Click clickEvent;
        public Calculation_AStar aStar;

        private List<Character_Explore> playerCharacters;

        public GameObject Captain { get; private set; }

        public void StartMoving()
        {
            if (clickEvent.pathFound == false) return;

            List<Node_AStar> entireTrack = new List<Node_AStar>();

            for (int i = 0; i < aStar.FinalTrack.Count; i++)
            {
                entireTrack.Add(aStar.FinalTrack[i]);
            }

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                playerCharacters[i].StartMoving(entireTrack);
            }
        }

        public void Initialize(List<GameObject> characters)
        {
            moveController.moving = false;
            Captain = characters[0];

            playerCharacters = new List<Character_Explore>();

            for (int i = 0; i < characters.Count; i++)
            {
                playerCharacters.Add(characters[i].GetComponent<Character_InDungeon>().MoveController);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
