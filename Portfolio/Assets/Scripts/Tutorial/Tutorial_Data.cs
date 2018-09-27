using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName = "", menuName = "Tutorial/Data", order = 1)]
    public class Tutorial_Data : ScriptableObject
    {
        public int intData;
        public float floatData;
        public string stringData;
        public int changedInt;

        public void CopyData(Tutorial_Data copiedData)
        {
            this.intData = copiedData.intData;
            this.floatData = copiedData.floatData;
            this.stringData = copiedData.stringData;
            this.changedInt = copiedData.changedInt;
        }
    }
}
