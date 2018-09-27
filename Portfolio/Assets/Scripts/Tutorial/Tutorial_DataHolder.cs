using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName = "", menuName = "Tutorial/DataHolder", order = 1)]
    public class Tutorial_DataHolder : ScriptableObject
    {
        public Tutorial_Database database;
        public int dataIndex;

        public List<Tutorial_Data> DataList { get { return dataList; } }

        [SerializeField]
        private List<Tutorial_Data> dataList = new List<Tutorial_Data>();

        public void AddData()
        {
            Tutorial_Data newData1 = CreateInstance<Tutorial_Data>();
            newData1.CopyData(database.data1);

            Tutorial_Data newData2 = CreateInstance<Tutorial_Data>();
            newData2.CopyData(database.data2);

            Tutorial_Data newData3 = CreateInstance<Tutorial_Data>();
            newData3.CopyData(database.data3);

            dataList.Add(newData1);
            dataList.Add(newData2);
            dataList.Add(newData3);
        }

        public void ClearData(bool editor = false)
        {
            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                dataList.RemoveAt(i);
            }

            dataList.Clear();
        }

        public void PrintData()
        {
            if (IndexOutOfRange(dataIndex, dataList) == true)
            {
                Debug.Log("Index is out of range.");
                return;
            }

            Debug.Log(dataList[dataIndex].stringData);
            Debug.Log(dataList[dataIndex].intData);
            Debug.Log(dataList[dataIndex].floatData);
            Debug.Log(dataList[dataIndex].changedInt);
        }

        public void AddOneToChangedInteger()
        {
            if (IndexOutOfRange(dataIndex, dataList) == true)
            {
                Debug.Log("Index is out of range.");
                return;
            }

            dataList[dataIndex].changedInt++;
        }

        private bool IndexOutOfRange(int index, List<Tutorial_Data> list)
        {
            if (index < 0) return true;
            if (index >= list.Count) return true;

            return false;
        }
    }
}
