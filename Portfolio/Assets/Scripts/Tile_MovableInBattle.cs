using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileDataSet
{
    public class Tile_MovableInBattle : MonoBehaviour
    {
        public Material normal;
        public Material attack;

        public Map_TileData TileData { get; private set; }

        public void SetDetails(Map_TileData tileData)
        {
            TileData = tileData;
            this.GetComponent<MeshRenderer>().material = normal;

            //if (targetInRange == true) this.GetComponent<MeshRenderer>().material = attack;
            bool targetInRange = TargetsInAttackRange();
        }

        private bool TargetsInAttackRange()
        {
            //List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            //int attackRange = turnController.CurrentTurnCharacter.AttackRange;

            //for (int i = 0; i < oppositeSide.Count; i++)
            //{
            //    if ((Mathf.Abs(oppositeSide[i].StandingTileX - x) + Mathf.Abs(oppositeSide[i].StandingTileZ - z)) <= attackRange) return true;
            //}

            return false;
        }
    }
}
