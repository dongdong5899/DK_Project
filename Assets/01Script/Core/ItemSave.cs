using DKProject.Combat;
using Doryu.JBSave;
using System;
using System.Collections.Generic;

namespace DKProject.Core
{
    public class ItemSave : ISavable<ItemSave>
    {
        public List<Pair<ItemSO, ItemData>> itemDataBase;


        public ItemSave()
        {
            itemDataBase = new List<Pair<ItemSO, ItemData>>();
        }


        public bool OnLoadData(ItemSave classData)
        {
            if (classData == null) return false;

            foreach (var pair in classData.itemDataBase)
            {
                if (pair.first == null)
                {
                    itemDataBase = new List<Pair<ItemSO, ItemData>>();
                    return false;
                }
            }
            itemDataBase = classData.itemDataBase;

            return true;
        }

        public void OnSaveData(string savedFileName)
        {
        }

        public void ResetData()
        {
            itemDataBase = new List<Pair<ItemSO, ItemData>>();
        }
    }

    [Serializable]
    public struct ItemData
    {
        public bool isUnlock;
        public int level;
        public int count;
        public int revolutionLevel;
    }
}
