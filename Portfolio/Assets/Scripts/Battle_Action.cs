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
        private string actionName;
        [SerializeField]
        private Character_State actionState;
        [SerializeField]
        private int range;
        [SerializeField]
        private float power;
        [SerializeField]
        private float scale;
        [SerializeField]
        private float splashedPowerRate;

        public string ActionName { get { return actionName; } }
        public Character_State ActionState { get { return actionState; } }
        public int Range { get { return range; } }
        public float Power { get { return power; } }
        public float Scale { get { return scale; } }
        public float SplashedPowerRate { get { return splashedPowerRate; } }

        public void Play()
        {
            turnController.CurrentTurnCharacter.SetState(actionState);
        }
    }
}
