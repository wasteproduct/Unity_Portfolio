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
            jsonStreamer = this.gameObject.GetComponent<Tutorial_StreamingAsset>();
            jsonStreamer.WriteJSON();
        }

        public void AddCharacter()
        {
            jsonStreamer = this.gameObject.GetComponent<Tutorial_StreamingAsset>();
            jsonStreamer.AddCharacter();
        }
    }
}
