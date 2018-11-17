using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileDataSet;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Action Manager", order = 1)]
    public class Battle_ActionManager : ScriptableObject
    {
        public Battle_MovableTilesManager movableTilesManager;
        public Battle_ActionType actionAttack;
        public Battle_ActionType actionSupport;
        public Battle_ActionType actionDebuff;

        public List<Battle_Action> ExecutableActions { get; private set; }
        public Battle_Action ExecutedAction { get; private set; }
        public bool NothingToDo { get { return ExecutedAction == null; } }

        public void SetExecutedAction(Battle_Action selectedAction)
        {
            ExecutedAction = null;
            ExecutedAction = selectedAction;
        }

        public void SetExecutableActions()
        {
            Tile_MovableInBattle destinationTile = movableTilesManager.DestinationTile.GetComponent<Tile_MovableInBattle>();

            ExecutableActions = new List<Battle_Action>(destinationTile.AvailableActions);
        }
    }
}
