using Doryu.JBSave;
using System.Numerics;
using UnityEngine;

namespace DKProject.Core
{
    public class ResourceSave : ISavable<ResourceSave>
    {
        public BigInteger exp;
        public BigInteger gold;
        public BigInteger diamond;
        public uint skillPoint;

        public void OnLoadData(ResourceSave classData)
        {
            if (classData == null) return;

            exp = classData.exp;
            gold = classData.gold;
            diamond = classData.diamond;
            skillPoint = classData.skillPoint;
        }

        public void OnSaveData(string savedFileName)
        {

        }

        public void ResetData()
        {
            exp = 0;
            gold = 0;
            diamond = 0;
            skillPoint = 0;
        }
    }
}
