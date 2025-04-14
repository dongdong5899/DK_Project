using Doryu.JBSave;
using UnityEngine;

namespace DKProject.Core
{
    public class ResourceSave : ISavable<ResourceSave>
    {
        public ulong exp;
        public ulong gold;
        public uint skillPoint;

        public void OnLoadData(ResourceSave classData)
        {
            if (classData == null)
                Debug.Log("นึ");

            exp = classData.exp;
            gold = classData.gold;
            skillPoint = classData.skillPoint;
        }

        public void OnSaveData(string savedFileName)
        {
            Debug.Log("asdf");
        }

        public void ResetData()
        {
            exp = 0;
            gold = 0;
            skillPoint = 0;
        }
    }
}
