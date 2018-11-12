using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_ActionSelectingManager : MonoBehaviour
    {
        public Battle_ActionManager actionManager;

        public GameObject[] actionButton;

        public void SetList()
        {
            List<Battle_Action> actions = actionManager.ExecutableActions;

            for (int i = 0; i < actions.Count; i++)
            {
                actionButton[i].gameObject.SetActive(true);
                actionButton[i].gameObject.GetComponent<Battle_ActionButton>().SetCorrespondingAction(actions[i]);
            }
        }

        //// Use this for initialization
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}
