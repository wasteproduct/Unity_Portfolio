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

            if ((aStar.FinalTrack.Count < 2) && (clickEvent.doorTileClicked == true))
            {
                clickEvent.doorTile.OpenDoor();
                return;
            }

            moveController.moving = true;

            List<Node_AStar> track = new List<Node_AStar>(aStar.FinalTrack);
            for (int i = 1; i < playerCharacters.Count; i++)
            {
                track.Insert(0, aStar.Node[playerCharacters[i].StandingTileX, playerCharacters[i].StandingTileZ]);
                playerCharacters[i].SetTrack(track);
            }

            StartCoroutine(Move());
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

        private IEnumerator Move()
        {
            int targetIndex = 1;
            float elapsedTime = 0.0f;
            float lerpTime = 0.0f;
            bool doorTileClicked = clickEvent.doorTileClicked;

            while (true)
            {
                if (elapsedTime >= moveController.ElapsedTimeLimit)
                {
                    targetIndex++;
                    elapsedTime = 0.0f;

                    if (targetIndex >= aStar.FinalTrack.Count)
                    {
                        if (doorTileClicked == true) clickEvent.doorTile.OpenDoor();

                        moveController.moving = false;
                        // 여기
                        //if(clickEvent.intoEnemyZone==true)

                        break;
                    }
                }

                elapsedTime += Time.deltaTime;
                lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    playerCharacters[i].Move(targetIndex, lerpTime);
                }

                yield return null;
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
