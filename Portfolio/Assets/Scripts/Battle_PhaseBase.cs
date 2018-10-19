using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class Battle_PhaseBase : MonoBehaviour
    {
        public abstract void ClosePhase();
        public abstract void EnterPhase();
    }
}
