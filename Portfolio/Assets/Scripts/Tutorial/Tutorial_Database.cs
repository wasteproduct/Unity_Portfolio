using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName = "", menuName = "Tutorial/Database", order = 1)]
    public class Tutorial_Database : ScriptableObject
    {
        public Tutorial_Data data1;
        public Tutorial_Data data2;
        public Tutorial_Data data3;
    }
}
