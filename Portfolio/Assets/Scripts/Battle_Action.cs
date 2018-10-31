using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Action", order = 1)]
    public class Battle_Action : ScriptableObject
    {
        public Battle_TurnController turnController;
        public Character_State actionState;

        public void Play()
        {
            turnController.CurrentTurnCharacter.SetState(actionState);
        }
    }
}
