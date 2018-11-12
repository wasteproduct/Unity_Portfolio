using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Action", order = 1)]
    public class Battle_Action : ScriptableObject
    {
        public Battle_TurnController turnController;

        [SerializeField]
        private Character_State actionState;

        public Character_State ActionState { get { return actionState; } }

        public void Play()
        {
            turnController.CurrentTurnCharacter.SetState(actionState);
        }
    }
}
