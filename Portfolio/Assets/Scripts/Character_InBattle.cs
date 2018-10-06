using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileDataSet;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/In Battle", order = 1)]
    public class Character_InBattle : ScriptableObject
    {
        public Character_Base CorrespondingCharacter { get; private set; }
        public float Health { get; private set; }
        public float PhysicalPower { get; private set; }
        public float PhysicalDefense { get; private set; }
        public float MagicalPower { get; private set; }
        public float MagicalDefense { get; private set; }
        public float EvadingChance { get; private set; }
        public float CriticalChance { get; private set; }

        public bool Dead { get; private set; }

        public Map_TileData StandingTile { get; set; }

        public void Initialize(Character_Base correspondingCharacter)
        {
            CorrespondingCharacter = correspondingCharacter;

            Health = 100.0f;
            PhysicalPower = 20.0f;
            PhysicalDefense = 2.0f;
            MagicalPower = 50.0f;
            MagicalDefense = 5.0f;
            EvadingChance = 10.0f;
            CriticalChance = 10.0f;

            Dead = false;
        }
    }
}
