using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tutorial
{
    public class Tutorial_Manager : MonoBehaviour
    {
        [SerializeField]
        private TextAsset questText;

        public void Run()
        {
            print(questText.name);
        }

        private void Start()
        {
            
        }
    }
}
