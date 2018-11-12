﻿using System.Collections;
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
        public Material skill;

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

            CheckSkillRange();
            //bool targetInAttackRange = TargetsInAttackRange();

            //if (targetInAttackRange == true)
            //{
            //    GetComponent<MeshRenderer>().material = attack;
            //    AttackTile = true;
            //}

            if (AttackTile == true) GetComponent<MeshRenderer>().material = attack;

            if (SkillTile == true) GetComponent<MeshRenderer>().material = skill;
        }

        private void CheckSkillRange()
        {
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            
            // temporary
            if (turnController.CurrentTurnCharacter.skill1 == null) return;
            int skillRange = turnController.CurrentTurnCharacter.skill1.Range;

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                if (oppositeSide[i].Dead == true) continue;

                int x = Mathf.Abs(oppositeSide[i].StandingTileX - TileData.X);
                int z = Mathf.Abs(oppositeSide[i].StandingTileZ - TileData.Z);

                if ((x + z) <= skillRange)
                {
                    SkillTile = true;
                    return;
                }
            }
        }

        private void CheckAttackRange()
        {
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            int attackRange = turnController.CurrentTurnCharacter.AttackRange;

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                if (oppositeSide[i].Dead == true) continue;

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
