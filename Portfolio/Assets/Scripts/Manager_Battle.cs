using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TileDataSet;

namespace Battle
{
    public class Manager_Battle : MonoBehaviour
    {
        public GameObject player;
        public GameObject tileMap;
        public Battle_MovableTilesManager movableTilesManager;
        public Battle_TurnController turnController;
        public Variable_Bool enemyTurn;
        public Battle_TargetManager targetManager;
        public Variable_Bool choosingTarget;
        public Manager_Layers layers;

        private Player_DungeonSettings playerManager;
        private List<Character_InBattle> inBattleCharactersPlayer;
        private List<Character_InBattle> inBattleEnemies;
        private GameObject target;

        public Character_InBattle CurrentTurnCharacter { get; private set; }
        public bool OutOfMovableRange(Map_TileData destinationTile)
        {
            return movableTilesManager.OutOfMovableRange(destinationTile);
        }

        public void StartAction()
        {
            ResetMaterials();

            if (enemyTurn.flag == true)
            {
                //target = targetManager.Enemy_ChooseTarget(CurrentTurnCharacter);
                CurrentTurnCharacter.gameObject.GetComponent<Enemy_Move>().StartMoving(movableTilesManager.MovableTiles, target);
            }
            else
            {
                targetManager.CountTargetsInAttackRange(CurrentTurnCharacter);
                StartCoroutine(CurrentTurnCharacterAction());
            }
        }

        public void Initialize(List<GameObject> enemiesInZone)
        {
            playerManager = player.GetComponent<Player_DungeonSettings>();

            movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);

            SetPlayerCharacters();

            SetEnemies(enemiesInZone);

            //turnController.Initialize(inBattleEnemies);

            target = null;

            CurrentTurnCharacter = inBattleCharactersPlayer[0];
            //movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator CurrentTurnCharacterAction()
        {
            choosingTarget.flag = true;

            while (true)
            {
                if (targetManager.PotentialTargets.Count <= 0) choosingTarget.flag = false;

                if (targetManager.PotentialTargets.Count == 1)
                {
                    target = targetManager.PotentialTargets[0];
                    choosingTarget.flag = false;
                }

                if (targetManager.PotentialTargets.Count > 1)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hitInfo;
                        if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
                        {
                            if (1 << hitInfo.collider.gameObject.layer == (int)layers.Enemy)
                            {
                                target = hitInfo.collider.gameObject;
                                choosingTarget.flag = false;
                            }
                        }
                    }
                }

                if (choosingTarget.flag == false) break;

                yield return null;
            }

            while (true)
            {
                if (target != null)
                {
                    DestroyTarget();
                    target = null;
                }

                if (CurrentTurnCharacter.ActionFinished() == true) break;

                yield return null;
            }

            bool rewind = AllFinishedTurn();

            if (rewind == true)
            {
                if (BattleOver() == true)
                {

                }
                else
                {
                    RecoverTurns();
                }
            }

            //CurrentTurnCharacter = turnController.SetCurrentTurnCharacter(inBattleCharactersPlayer, inBattleEnemies, rewind);
            //movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
            StartAction();
        }

        private void ResetMaterials()
        {
            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                inBattleEnemies[i].HighlightAsTarget(false);
            }
        }

        private void DestroyTarget()
        {
            if (inBattleCharactersPlayer.Contains(target.GetComponent<Character_InBattle>()) == true)
            {
                inBattleCharactersPlayer.Remove(target.GetComponent<Character_InBattle>());
                Destroy(target.gameObject);
                return;
            }

            if (inBattleEnemies.Contains(target.GetComponent<Character_InBattle>()) == true)
            {
                inBattleEnemies.Remove(target.GetComponent<Character_InBattle>());
                Destroy(target.gameObject);
                return;
            }
        }

        private void RecoverTurns()
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                inBattleCharactersPlayer[i].SetTurnFinished(false);
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                inBattleEnemies[i].SetTurnFinished(false);
            }
        }

        private bool BattleOver()
        {
            return false;
        }

        private bool AllFinishedTurn()
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                if (inBattleCharactersPlayer[i].TurnFinished == false) return false;
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                if (inBattleEnemies[i].TurnFinished == false) return false;
            }

            return true;
        }

        private void SetPlayerCharacters()
        {
            inBattleCharactersPlayer = new List<Character_InBattle>();

            for (int i = 0; i < playerManager.PlayerCharacters.Count; i++)
            {
                if (playerManager.PlayerCharacters[i].GetComponent<Character_InBattle>().Dead == true)
                {
                    playerManager.PlayerCharacters[i].gameObject.SetActive(false);
                    continue;
                }

                inBattleCharactersPlayer.Add(playerManager.PlayerCharacters[i].GetComponent<Character_InBattle>());
            }
        }

        private void SetEnemies(List<GameObject> enemiesInZone)
        {
            inBattleEnemies = new List<Character_InBattle>();

            for (int i = 0; i < enemiesInZone.Count; i++)
            {
                enemiesInZone[i].GetComponent<Character_InBattle>().Initialize(tileMap.GetComponent<Map_Main>().MapData, true);
                enemiesInZone[i].GetComponent<Enemy_Move>().Initialize(tileMap.GetComponent<Map_Main>().MapData, StartEnemyAction);

                inBattleEnemies.Add(enemiesInZone[i].GetComponent<Character_InBattle>());
            }
        }

        private void StartEnemyAction()
        {
            StartCoroutine(EnemyAction());
        }

        private bool EnemyNextToTarget()
        {
            Character_InBattle targetScript = target.GetComponent<Character_InBattle>();

            if ((Mathf.Abs(targetScript.StandingTileX - CurrentTurnCharacter.StandingTileX) + Mathf.Abs(targetScript.StandingTileZ - CurrentTurnCharacter.StandingTileZ)) == 1) return true;

            return false;
        }

        private IEnumerator EnemyAction()
        {
            while (true)
            {
                if (EnemyNextToTarget() == true)
                {
                    print("player hp -47479651");
                }

                if (CurrentTurnCharacter.ActionFinished() == true) break;

                yield return null;
            }

            bool rewind = AllFinishedTurn();

            if (rewind == true)
            {
                if (BattleOver() == true)
                {

                }
                else
                {
                    RecoverTurns();
                }
            }

            target = null;
            //CurrentTurnCharacter = turnController.SetCurrentTurnCharacter(inBattleCharactersPlayer, inBattleEnemies, rewind);
            //movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
        }

        public void FinishBattle()
        {

        }
    }
}
