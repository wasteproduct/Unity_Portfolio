﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

namespace Player
{
    public class Player_Move : MonoBehaviour
    {
        [SerializeField]
        private Player_Navigator navigator;
        public Calculation_Move moveController;
        public Event_Click clickEvent;
        public Calculation_AStar aStar;
        public GameObject dungeonPlay;
        public Manager_DungeonPhase phaseManager;
        public GameObject battleManager;
        public Character_State idleExploration;
        public Character_State idleBattle;
        public Character_State runExploration;

        private List<GameObject> characters;

        public GameObject Captain { get; private set; }

        public void StartMoving()
        {
            if (phaseManager.CurrentPhase == phaseManager.Phase_Battle) return;

            StartMove_Explore();
        }

        public void Initialize(List<GameObject> playerCharacters)
        {
            moveController.moving = false;

            characters = new List<GameObject>(playerCharacters);

            Captain = characters[0];
        }

        private void StartMove_Explore()
        {
            if (clickEvent.pathFound == false) return;

            if (aStar.FinalTrack.Count < 2)
            {
                //if (clickEvent.doorTileClicked == true) clickEvent.doorTile.OpenDoor();
                if (clickEvent.interactorClicked == true) clickEvent.interactorTile.React();

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

            SetState_Run();

            StartCoroutine(Move_Explore());
        }

        private void SetState_Run()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_StateManager>().SetState(runExploration);
            }
        }

        private void SetState_Idle(bool battlePhase)
        {
            Character_State idle = (battlePhase == true) ? idleBattle : idleExploration;

            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_StateManager>().SetState(idle);
            }
        }

        // reveal map
        private IEnumerator Move_Explore()
        {
            int targetIndex = 1;
            float elapsedTime = 0.0f;
            float lerpTime = 0.0f;
            //bool doorTileClicked = clickEvent.doorTileClicked;
            bool interactorClicked = clickEvent.interactorClicked;

            while (true)
            {
                if (elapsedTime >= moveController.ElapsedTimeLimit)
                {
                    if (Captain.GetComponent<Character_ExploreCaptain>().IntoEnemyZone == true)
                    {
                        moveController.moving = false;

                        FogOfWar_Manager.Instance.RevealArea(Captain.GetComponent<Character_ExploreCaptain>().SteppedEnemyZone.GetComponent<Map_EnemyZone>());
                        List<GameObject> enemiesInZone = Captain.GetComponent<Character_ExploreCaptain>().SteppedEnemyZone.GetComponent<Map_EnemyZone>().StayingEnemies;
                        Captain.GetComponent<Character_ExploreCaptain>().DestroySteppedEnemyZone();
                        dungeonPlay.GetComponent<Manager_DungeonPlay>().StartBattle(enemiesInZone);

                        SetState_Idle(true);

                        navigator.UpdateMinimap();

                        break;
                    }

                    targetIndex++;
                    elapsedTime = 0.0f;
                    UpdateStartingRotations();
                    FogOfWar_Manager.Instance.RevealArea();

                    if (targetIndex >= aStar.FinalTrack.Count)
                    {
                        //if (doorTileClicked == true) clickEvent.doorTile.OpenDoor();
                        if (interactorClicked == true) clickEvent.interactorTile.React();

                        moveController.moving = false;

                        SetState_Idle(false);

                        navigator.UpdateMinimap();

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

        private void UpdateStartingRotations()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_InDungeon>().MoveController.UpdateStartingRotation();
            }
        }
    }
}
