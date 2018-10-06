using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        public bool PlayerTurn { get; private set; }
        public bool EnemyTurn { get; private set; }

        public void Initialize()
        {
            PlayerTurn = true;
            EnemyTurn = false;
        }

        public void TurnOver()
        {
            PlayerTurn = !PlayerTurn;
            EnemyTurn = !EnemyTurn;
        }
    }
}
