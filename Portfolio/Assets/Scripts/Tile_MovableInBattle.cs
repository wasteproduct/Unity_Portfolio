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

        public void SetDetails(Map_TileData tileData)
        {
            TileData = tileData;
            this.GetComponent<MeshRenderer>().material = normal;

            bool targetInRange = TargetsInAttackRange();

            if (targetInRange == true) this.GetComponent<MeshRenderer>().material = attack;
        }

        private bool TargetsInAttackRange()
        {
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            int attackRange = turnController.CurrentTurnCharacter.AttackRange;

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                int x = Mathf.Abs(oppositeSide[i].StandingTileX - TileData.X);
                int z = Mathf.Abs(oppositeSide[i].StandingTileZ - TileData.Z);

                if ((x + z) <= attackRange) return true;
            }

            return false;
        }
    }
}
