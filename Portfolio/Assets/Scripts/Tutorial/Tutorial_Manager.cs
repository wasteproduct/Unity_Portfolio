using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

namespace Tutorial
{
    public class Tutorial_Manager : MonoBehaviour
    {
        [SerializeField]
        private Tutorial_Soldier soldier;

        public void Run()
        {
            soldier.gameObject.transform.position += new Vector3(0, 0, 1);
        }

        private void Start()
        {
            
        }
    }
}
