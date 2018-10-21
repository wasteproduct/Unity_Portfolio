using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Phase Manager", order = 1)]
    public class Manager_BattlePhase : ScriptableObject
    {
        public void EnterNextPhase(Battle_PhaseBase currentPhase, Battle_PhaseBase nextPhase)
        {
            currentPhase.ClosePhase();
            currentPhase.enabled = false;

            nextPhase.enabled = true;
            nextPhase.EnterPhase();
        }
    }
}
