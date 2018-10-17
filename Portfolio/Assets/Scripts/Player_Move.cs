using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using Battle;

namespace Player
{
    public class Player_Move : MonoBehaviour
    {
        public Calculation_Move moveController;
        public Event_Click clickEvent;
        public Calculation_AStar aStar;
        public GameObject dungeonPlay;
        public Manager_DungeonPhase phaseManager;
        public GameObject battleManager;

        private List<GameObject> characters;

        public GameObject Captain { get; private set; }

        public void StartMoving()
        {
            if (phaseManager.CurrentPhase == phaseManager.Phase_Battle) StartMove_Battle();
            else StartMove_Explore();
        }

        public void Initialize(List<GameObject> playerCharacters)
        {
            moveController.moving = false;
            //clickEvent.intoEnemyZone = false;

            characters = new List<GameObject>(playerCharacters);

            Captain = characters[0];
        }

        private void StartMove_Battle()
        {
            if (clickEvent.pathFound == false) return;

            if (battleManager.GetComponent<Manager_Battle>().OutOfMovableRange(clickEvent.destinationTile) == true)
            {
                print("Out of movable range.");
                return;
            }

            moveController.moving = true;

            StartCoroutine(Move_Battle());
        }

        private IEnumerator Move_Battle()
        {
            int targetIndex = 1;
            float elapsedTime = 0.0f;
            float lerpTime = 0.0f;

            while (true)
            {
                if (elapsedTime >= moveController.ElapsedTimeLimit)
                {
                    targetIndex++;
                    elapsedTime = 0.0f;

                    if (targetIndex >= aStar.FinalTrack.Count)
                    {
                        moveController.moving = false;
                        battleManager.GetComponent<Manager_Battle>().StartAction();

                        break;
                    }
                }

                elapsedTime += Time.deltaTime;
                lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

                battleManager.GetComponent<Manager_Battle>().CurrentTurnCharacter.Move(targetIndex, lerpTime);

                yield return null;
            }
        }

        private void StartMove_Explore()
        {
            if (clickEvent.pathFound == false) return;

            if ((aStar.FinalTrack.Count < 2) && (clickEvent.doorTileClicked == true))
            {
                clickEvent.doorTile.OpenDoor();
                return;
            }

            moveController.moving = true;

            List<Node_AStar> track = new List<Node_AStar>(aStar.FinalTrack);
            for (int i = 1; i < characters.Count; i++)
            {
                Character_Explore characterMoveController = characters[i].GetComponent<Character_InDungeon>().MoveController;
                track.Insert(0, aStar.Node[characterMoveController.StandingTileX, characterMoveController.StandingTileZ]);
                characters[i].GetComponent<Character_InDungeon>().MoveController.SetTrack(track);
            }

            StartCoroutine(Move_Explore());
        }

        private IEnumerator Move_Explore()
        {
            int targetIndex = 1;
            float elapsedTime = 0.0f;
            float lerpTime = 0.0f;
            bool doorTileClicked = clickEvent.doorTileClicked;

            while (true)
            {
                if (elapsedTime >= moveController.ElapsedTimeLimit)
                {
                    if (Captain.GetComponent<Character_ExploreCaptain>().IntoEnemyZone == true)
                    {
                        moveController.moving = false;

                        List<GameObject> enemiesInZone = Captain.GetComponent<Character_ExploreCaptain>().SteppedEnemyZone.GetComponent<Map_EnemyZone>().StayingEnemies;
                        Captain.GetComponent<Character_ExploreCaptain>().DestroySteppedEnemyZone();
                        dungeonPlay.GetComponent<Manager_DungeonPlay>().StartBattle(enemiesInZone);

                        break;
                    }

                    targetIndex++;
                    elapsedTime = 0.0f;

                    if (targetIndex >= aStar.FinalTrack.Count)
                    {
                        if (doorTileClicked == true) clickEvent.doorTile.OpenDoor();

                        moveController.moving = false;

                        //if (clickEvent.intoEnemyZone == true)
                        //{
                        //    Destroy(clickEvent.destroyedObject.gameObject);
                        //    dungeonPlay.GetComponent<Manager_DungeonPlay>().StartBattle();
                        //}

                        break;
                    }
                }

                elapsedTime += Time.deltaTime;
                lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].GetComponent<Character_InDungeon>().MoveController.Move(targetIndex, lerpTime);
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
