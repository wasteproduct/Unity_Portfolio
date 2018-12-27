using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_Manager : MonoBehaviour
    {
        private Tutorial_StreamingAsset jsonStreamer;

        public void WriteJSON()
        {
            jsonStreamer = gameObject.GetComponent<Tutorial_StreamingAsset>();
            jsonStreamer.WriteJSON();
        }

        public void AddCharacter()
        {
            jsonStreamer = gameObject.GetComponent<Tutorial_StreamingAsset>();
            jsonStreamer.AddCharacter();
        }

        private List<int> intList;

        private void Start()
        {

        }
    }

    public class IntegerAdder
    {
        public IntegerAdder(List<int> intList)
        {
            for (int i = 0; i < 5; i++)
            {
                intList.Add(i);
            }
        }
    }
}
