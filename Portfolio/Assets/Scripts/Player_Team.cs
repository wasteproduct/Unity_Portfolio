using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using MapDataSet;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Team", order = 1)]
    public class Player_Team : ScriptableObject
    {
        public Variable_Int currentTileX;
        public Variable_Int currentTileZ;

        public Character_Base captain;
        public Character_Base[] teamFellow;

        //public Character_InBattle characterInBattleBase;

        //private List<Character_InBattle> inBattleCharacters = new List<Character_InBattle>();

        //public List<Character_InBattle> InBattleCharacters { get { return inBattleCharacters; } }

        //public void Initialize_Battle(Map_Data mapData)
        //{
        //    ClearInBattleCharacters();

        //    InitializeInBattleCharacters();

        //    inBattleCharacters[0].StandingTile = mapData.TileData[currentTileX.value, currentTileZ.value];
        //}

        //private void InitializeInBattleCharacters()
        //{
        //    Character_InBattle captainInBattle = CreateInstance<Character_InBattle>();
        //    captainInBattle.Initialize(captain);

        //    inBattleCharacters.Add(captainInBattle);

        //    for (int i = 0; i < teamFellow.Length; i++)
        //    {
        //        if (teamFellow[i] == null) continue;

        //        Character_InBattle newCharacter = CreateInstance<Character_InBattle>();
        //        newCharacter.Initialize(teamFellow[i]);

        //        inBattleCharacters.Add(newCharacter);
        //    }
        //}

        //private void ClearInBattleCharacters()
        //{
        //    for (int i = inBattleCharacters.Count - 1; i >= 0; i--)
        //    {
        //        inBattleCharacters.RemoveAt(i);
        //    }

        //    inBattleCharacters.Clear();
        //}
    }
}
