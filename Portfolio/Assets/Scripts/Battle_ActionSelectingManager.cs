using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_ActionSelectingManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] actionButton;
        [SerializeField]
        private Battle_ActionManager actionManager;

        public void DisableButtons()
        {
            for (int i = 0; i < actionButton.Length; i++)
            {
                actionButton[i].gameObject.SetActive(false);
            }
        }

        public void SetList()
        {
            GetComponent<RectTransform>().position = Input.mousePosition;

            List<Battle_Action> actions = actionManager.ExecutableActions;

            for (int i = 0; i < actions.Count; i++)
            {
                actionButton[i].gameObject.SetActive(true);
                actionButton[i].gameObject.GetComponent<Battle_ActionButton>().SetCorrespondingAction(actions[i]);
            }
        }
    }
}
