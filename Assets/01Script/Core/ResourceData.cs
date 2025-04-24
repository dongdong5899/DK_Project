using Doryu.JBSave;
using System;
using System.Numerics;

namespace DKProject.Core
{
    public static class ResourceData
    {
        public static ResourceSave save;
        public static event Action OnChangeValue;

        private static string fileName = "Resource";

        static ResourceData()
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
                case ResourceType.SkillPoint:
                    {
                        if (save.skillPoint < (uint)value) return false;

                        save.skillPoint -= (uint)value;
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
                case ResourceType.SkillPoint:
                    save.skillPoint += (uint)value;
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

        #endregion

        #region ResourceGetter

        public static BigInteger GetResource(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.SkillPoint:
                    return save.skillPoint;
                case ResourceType.Gold:
                    return save.gold;
                case ResourceType.Diamond:
                    return save.diamond;
            }

            return 0;
        }

        public static uint GetSkillPoint()
            => save.skillPoint;

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
        SkillPoint,
        Gold,
        Diamond,
    }
}
