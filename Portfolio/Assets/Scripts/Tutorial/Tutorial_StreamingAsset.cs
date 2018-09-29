using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tutorial
{
    public class Tutorial_StreamingAsset : MonoBehaviour
    {
        public void WriteJSON()
        {
            string jsonString = File.ReadAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json");

            Jason jason = JsonUtility.FromJson<Jason>(jsonString);

            string jasonInformation = jsonString;
            //jason.Level += 2;
            jason.Stats[0]++;
            jasonInformation = JsonUtility.ToJson(jason);

            File.WriteAllText(Application.streamingAssetsPath + "/Tutorial_StreamingAsset.json", jasonInformation);

            Debug.Log(jasonInformation);
        }
    }

    [System.Serializable]
    public class Jason
    {
        public string Name;
        public int Level;
        public int[] Stats;
    }
}
