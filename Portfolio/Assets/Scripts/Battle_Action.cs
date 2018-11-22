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
        private Battle_ActionType actionType;
        [SerializeField]
        private int range;
        [SerializeField]
        private float power;
        [SerializeField]
        private int scale;
        [SerializeField]
        private float splashedPowerRate;
        [SerializeField]
        private Debuff_Data debuffData;
        [SerializeField]
        private CustomSound actionSound;

        public string ActionName { get { return actionName; } }
        public Character_State ActionState { get { return actionState; } }
        public Battle_ActionType ActionType { get { return actionType; } }
        public int Range { get { return range; } }
        public float Power { get { return power; } }
        public int Scale { get { return scale; } }
        public float SplashedPowerRate { get { return splashedPowerRate; } }
        public Debuff_Data DebuffData { get { return debuffData; } }
        public CustomSound ActionSound { get { return actionSound; } }

        public void Play()
        {
            turnController.CurrentTurnCharacter.SetState(actionState);
        }
    }
}
