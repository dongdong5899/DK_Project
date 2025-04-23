using Doryu.JBSave;
using System;
using System.Numerics;

namespace DKProject.Core
{
    public static class ResourceManager
    {
        public static ResourceSave save;
        public static event Action OnChangeValue;

        private static string fileName = "Resource";

        // 다음 경험치 계산을 그냥 프로퍼티에 박아버려도 될 듯
        public static BigInteger _nextRequireExp => save.level * 10;

        static ResourceManager()
        {
            Load();
        }

        public static void Start()
        {
            //save = new ResourceSave();
            //save.ResetData();
        }

        #region ResourceRemover

        public static bool TryRemoveResource(ResourceType resourceType, BigInteger value)
        {
            switch (resourceType)
            {
                case ResourceType.EXP:
                    {
                        if (save.exp < value) return false;

                        save.exp -= value;
                        break;
                    }
                case ResourceType.Gold:
                    {
                        if (save.gold < value) return false;

                        save.gold -= value;
                        break;
                    }
                case ResourceType.Diamond:
                    {
                        if (save.diamond < value) return false;

                        save.diamond -= value;
                        break;
                    }
            }

            OnChangeValue?.Invoke();
            Save();
            return true;
        }

        public static bool TryRemoveSkillPoint(uint skillPoint)
        {
            if (save.skillPoint < skillPoint) return false;

            save.skillPoint -= skillPoint;
            return true;
        }

        #endregion

        #region ResourceAdder

        public static void AddResource(ResourceType resource, BigInteger value)
        {
            switch (resource)
            {
                case ResourceType.EXP:
                    AddExp(value);
                    break;
                case ResourceType.Gold:
                    save.gold += value;
                    break;
                case ResourceType.Diamond:
                    save.diamond += value;
                    break;
            }

            OnChangeValue?.Invoke();
            Save();
        }

        public static void AddExp(BigInteger value)
        {
            save.exp += value;

            if (save.exp >= _nextRequireExp)
            {
                save.level++;
            }
        }

        public static void AddSkillPoint(uint value)
        {
            save.skillPoint -= value;
            Save();
        }

        #endregion

        #region ResourceGetter

        public static BigInteger GetResource(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.EXP:
                    return save.exp;
                case ResourceType.Gold:
                    return save.gold;
                case ResourceType.Diamond:
                    return save.diamond;
            }

            return 0;
        }

        public static uint GetSkillPoint()
            => save.skillPoint;

        public static uint GetLevel()
            => save.level;

        #endregion

        public static void Save()
        {
            save.SaveJson<ResourceSave>(fileName);
        }

        public static void Load()
        {
            save = new ResourceSave();
            if (save.LoadJson<ResourceSave>(fileName) == false)
            {
                save.ResetData();
            }

            OnChangeValue?.Invoke();
        }

    }

    public enum ResourceType
    {
        EXP,
        Gold,
        Diamond,
    }
}
