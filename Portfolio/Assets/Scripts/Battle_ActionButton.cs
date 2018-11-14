using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class Battle_ActionButton : MonoBehaviour
    {
        public GameObject battleManager;

        public Text buttonText;

        public Battle_Action CorrespondingAction { get; private set; }

        public void SelectAction()
        {
            battleManager.GetComponent<Battle_PhaseSelectingAction>().SelectAction(CorrespondingAction);
        }

        public void SetCorrespondingAction(Battle_Action correspondingAction)
        {
            CorrespondingAction = correspondingAction;

            buttonText.text = CorrespondingAction.ActionName;
        }
    }
}
