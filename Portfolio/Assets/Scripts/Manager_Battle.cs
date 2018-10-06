using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Battle
{
    public class Manager_Battle : MonoBehaviour
    {
        public Player_Team playerTeam;
        //public ENEMY enemies

        private bool acting;

        // temporary

        public void Initialize()
        {
            acting = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (acting == true) return;

            StartCoroutine(CharacterAction());
        }

        private void TurnOver()
        {

        }

        private IEnumerator CharacterAction()
        {
            acting = true;

            yield return null;
        }
    }
}
