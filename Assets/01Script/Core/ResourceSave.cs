using Doryu.JBSave;
using System.Numerics;

namespace DKProject.Core
{
    public class ResourceSave : ISavable<ResourceSave>
    {
        public uint level;
        public string expStr;
        public string goldStr;
        public string diamondStr;
        public uint skillPoint;

        public BigInteger exp;
        public BigInteger gold;
        public BigInteger diamond;

        public void OnLoadData(ResourceSave classData)
        {
            if (classData == null) return;

            level = classData.level;
            exp = BigInteger.Parse(classData.expStr);
            gold = BigInteger.Parse(classData.goldStr);
            diamond = BigInteger.Parse(classData.diamondStr);
            skillPoint = classData.skillPoint;
        }

        public void OnSaveData(string savedFileName)
        {
            expStr = exp.ToString();
            goldStr = gold.ToString();
            diamondStr = diamond.ToString();
        }

        public void ResetData()
        {
            level = 1;
            exp = 0;
            gold = 0;
            diamond = 0;
            skillPoint = 0;
            this.SaveJson("Resource");
        }
    }
}
