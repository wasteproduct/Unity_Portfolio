using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Phase Manager", order = 1)]
    public class Manager_BattlePhase : ScriptableObject
    {
        public List<Battle_PhaseBase> Phases { get; private set; }
        public Battle_PhaseBase CurrentPhase { get; private set; }

        public void Initialize(Battle_PhaseBase[] phases)
        {
            Phases = new List<Battle_PhaseBase>();

            for (int i = 0; i < phases.Length; i++)
            {
                for (int j = 0; j < phases.Length - 1; j++)
                {
                    if (phases[j].phaseNumber > phases[j + 1].phaseNumber)
                    {
                        Battle_PhaseBase latterPhase = phases[j];
                        phases[j] = phases[j + 1];
                        phases[j + 1] = latterPhase;
                    }
                }
            }

            for (int i = 0; i < phases.Length; i++)
            {
                Phases.Add(phases[i]);
            }

            Phases[0].enabled = true;
            Phases[0].EnterPhase();

            CurrentPhase = Phases[0];
        }

        public void EnterNextPhase()
        {
            CurrentPhase.ClosePhase();
            CurrentPhase.enabled = false;

            int currentPhaseNumber = CurrentPhase.phaseNumber;
            currentPhaseNumber++;
            if (currentPhaseNumber >= Phases.Count) currentPhaseNumber = 0;

            CurrentPhase = Phases[currentPhaseNumber];

            CurrentPhase.enabled = true;
            CurrentPhase.EnterPhase();
        }
    }
}
