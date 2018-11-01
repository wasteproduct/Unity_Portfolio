using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Object Manager", order = 1)]
    public class Battle_ObjectManager : ScriptableObject
    {
        public Variable_Bool choosingTarget;
        public GameObject targetMarkPrefab;

        public List<GameObject> TargetMarks { get; private set; }

        public void DisableTargetMarks()
        {
            for (int i = 0; i < TargetMarks.Count; i++)
            {
                TargetMarks[i].gameObject.SetActive(false);
            }
        }

        public void Initialize()
        {
            choosingTarget.flag = false;

            SetupTargetMarks();
        }

        private void SetupTargetMarks()
        {
            TargetMarks = new List<GameObject>();

            for (int i = 0; i < 3; i++)
            {
                TargetMarks.Add(Instantiate(targetMarkPrefab));
            }

            DisableTargetMarks();
        }
    }
}
