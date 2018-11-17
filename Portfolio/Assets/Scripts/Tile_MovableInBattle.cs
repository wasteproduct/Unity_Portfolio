using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

namespace TileDataSet
{
    public class Tile_MovableInBattle : MonoBehaviour
    {
        public Battle_TurnController turnController;
        public Battle_ActionManager actionManager;
        public Material tileNormal;
        public Material tileAttack;
        public Material tileSkillAttack;
        public Material tileSkillSupport;
        public Material tileSkillDebuff;

        public Map_TileData TileData { get; private set; }
        public List<Battle_Action> AvailableActions { get; private set; }

        public void SetDetails(Map_TileData tileData)
        {
            GetComponent<MeshRenderer>().material = tileNormal;

            TileData = tileData;
            AvailableActions = new List<Battle_Action>();

            CheckAttackRange();

            CheckAttackSkillsRange();
        }

        private void CheckAttackSkillsRange()
        {
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            Battle_Action[] skills = turnController.CurrentTurnCharacter.actionSkills;

            for (int i = 0; i < skills.Length; i++)
            {
                int skillRange = turnController.CurrentTurnCharacter.actionSkills[i].Range;

                for (int j = 0; j < oppositeSide.Count; j++)
                {
                    if (oppositeSide[j].Dead == true) continue;

                    int x = Mathf.Abs(oppositeSide[j].StandingTileX - TileData.X);
                    int z = Mathf.Abs(oppositeSide[j].StandingTileZ - TileData.Z);

                    if ((x + z) <= skillRange)
                    {
                        AvailableActions.Add(turnController.CurrentTurnCharacter.actionSkills[i]);
                        GetComponent<MeshRenderer>().material = tileSkillAttack;
                        return;
                    }
                }
            }
        }

        private void CheckAttackRange()
        {
            if (turnController.CurrentTurnCharacter.actionAttack == null) return;

            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            int attackRange = turnController.CurrentTurnCharacter.actionAttack.Range;

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                if (oppositeSide[i].Dead == true) continue;

                int x = Mathf.Abs(oppositeSide[i].StandingTileX - TileData.X);
                int z = Mathf.Abs(oppositeSide[i].StandingTileZ - TileData.Z);

                if ((x + z) <= attackRange)
                {
                    AvailableActions.Add(turnController.CurrentTurnCharacter.actionAttack);
                    GetComponent<MeshRenderer>().material = tileAttack;
                    return;
                }
            }
        }
    }
}
