using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Inventory", order = 1)]
    public class Player_Inventory : ScriptableObject
    {
        [SerializeField]
        private List<Item_Base> items = new List<Item_Base>();

        public List<Item_Base> Items { get { return items; } }

        public void RemoveItem_ByID(Item_ID removedID, int removedNumber = 1)
        {
            int removedCount = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemID == removedID)
                {
                    items.Remove(items[i]);

                    removedCount++;

                    if (removedCount >= removedNumber) return;
                }
            }
        }

        public void RemoveItem(Item_Base usedItem)
        {
            if (items.Contains(usedItem) == true) items.Remove(usedItem);
        }

        public void AddNewItem(Item_Base newItem)
        {
            items.Add(newItem);
        }

        private void OnDisable()
        {
            items.Clear();
            items = null;
        }
    }
}
