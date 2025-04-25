using Doryu.JBSave;
using System.Numerics;

namespace DKProject.Core
{
    public class ResourceSave : ISavable<ResourceSave>
    {
        public string goldStr;
        public string diamondStr;

        public uint skillPoint;
        public BigInteger gold;
        public BigInteger diamond;

        public bool OnLoadData(ResourceSave classData)
        {
            if (classData == null) return false;

            skillPoint = classData.skillPoint;
            gold = BigInteger.Parse(classData.goldStr);
            diamond = BigInteger.Parse(classData.diamondStr);

            return true;
        }

        public void OnSaveData(string savedFileName)
        {
            goldStr = gold.ToString();
            diamondStr = diamond.ToString();
        }

        public void ResetData()
        {
            skillPoint = 0;
            gold = 0;
            diamond = 0;
            this.SaveJson("Resource");
        }
    }
}
