using Doryu.JBSave;

namespace DKProject
{
    public class PlayerSave : ISavable<PlayerSave>
    {
        public uint level;
        public ulong exp;

        public bool OnLoadData(PlayerSave classData)
        {
            level = classData.level;
            exp = classData.exp;

            return true;
        }

        public void OnSaveData(string savedFileName)
        {

        }

        public void ResetData()
        {
            level = 1;
            exp = 0;
        }
    }
}
