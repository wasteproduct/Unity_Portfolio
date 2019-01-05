using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tutorial
{
    public class Tutorial_Manager : MonoBehaviour
    {
        [SerializeField]
        private string acquireChan;

        public void Run()
        {
            //string playerDataJSON = File.ReadAllText(Application.streamingAssetsPath + "/Editor_PlayerData.json");
            string acquireChanText = File.ReadAllText(Application.streamingAssetsPath + "/" + acquireChan + ".txt");

            print(acquireChanText);
        }

        private void Start()
        {
            
        }
    }
}
