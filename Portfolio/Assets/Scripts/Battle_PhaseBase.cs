using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class Battle_PhaseBase : MonoBehaviour
    {
        public int phaseNumber;
        public Manager_BattlePhase phaseManager;
        public Battle_TurnController turnController;

        public abstract void ClickWork();
        public abstract void ClosePhase();
        public abstract void EnterPhase();
    }
}
