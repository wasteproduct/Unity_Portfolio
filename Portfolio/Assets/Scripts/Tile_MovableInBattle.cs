using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

namespace TileDataSet
{
    public class Tile_MovableInBattle : MonoBehaviour
    {
        public Battle_TurnController turnController;
        public Material normal;
        public Material attack;

        public Map_TileData TileData { get; private set; }
        public bool AttackTile { get; private set; }
        public bool SkillTile { get; private set; }

        public void SetDetails(Map_TileData tileData)
        {
            GetComponent<MeshRenderer>().material = normal;

            TileData = tileData;
            AttackTile = false;
            SkillTile = false;

            CheckAttackRange();
            //bool targetInAttackRange = TargetsInAttackRange();

            //if (targetInAttackRange == true)
            //{
            //    GetComponent<MeshRenderer>().material = attack;
            //    AttackTile = true;
            //}

            if (AttackTile == true) GetComponent<MeshRenderer>().material = attack;
        }

        private void CheckAttackRange()
        {
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            int attackRange = turnController.CurrentTurnCharacter.AttackRange;

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                int x = Mathf.Abs(oppositeSide[i].StandingTileX - TileData.X);
                int z = Mathf.Abs(oppositeSide[i].StandingTileZ - TileData.Z);

                if ((x + z) <= attackRange)
                {
                    AttackTile = true;
                    return;
                }
            }
        }

        //private bool TargetsInAttackRange()
        //{
        //    List<Character_InBattle> oppositeSide = turnController.OppositeSide;
        //    int attackRange = turnController.CurrentTurnCharacter.AttackRange;

        //    for (int i = 0; i < oppositeSide.Count; i++)
        //    {
        //        int x = Mathf.Abs(oppositeSide[i].StandingTileX - TileData.X);
        //        int z = Mathf.Abs(oppositeSide[i].StandingTileZ - TileData.Z);

        //        if ((x + z) <= attackRange) return true;
        //    }

        //    return false;
        //}
    }
}
