using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Action Manager", order = 1)]
    public class Battle_ActionManager : ScriptableObject
    {
        public Battle_ActionList actionList;
        public Battle_MovableTilesManager movableTilesManager;

        public List<Battle_Action> ExecutableActions { get; private set; }

        public void SetExecutableActions()
        {
            ExecutableActions = new List<Battle_Action>();

            CheckAttackTile();
        }

        private void CheckAttackTile()
        {
            //if(movableTilesManager)
        }
    }
}
