using UnityEngine;

namespace Battle
{
    public abstract class Battle_PhaseBase : MonoBehaviour
    {
        [SerializeField]
        protected int phaseNumber;
        [SerializeField]
        protected Manager_BattlePhase phaseManager;
        [SerializeField]
        protected Battle_TurnController turnController;

        public int PhaseNumber { get { return phaseNumber; } }

        public abstract void ClickWork();
        public abstract void ClosePhase();
        public abstract void EnterPhase();
    }
}
