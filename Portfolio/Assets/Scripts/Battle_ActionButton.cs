using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class Battle_ActionButton : MonoBehaviour
    {
        public Text buttonText;

        public Battle_Action CorrespondingAction { get; private set; }

        public void SetCorrespondingAction(Battle_Action correspondingAction)
        {
            CorrespondingAction = correspondingAction;
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
