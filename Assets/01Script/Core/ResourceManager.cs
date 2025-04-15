using DKProject.Cores;
using Doryu.JBSave;
using Mono.Cecil;
using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Core
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        public ResourceSave save;
        public event Action onChangeValue;

        private string fileName = "Resource";

        public BigInteger _nextRequireExp => save.level * 10;

        public void Start()
        {
            save = new ResourceSave();
            save.ResetData();
            //Load();
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
                Save();

            if (Keyboard.current.oKey.wasPressedThisFrame)
                AddResource(ResourceType.Exp, 1000);

            if (Keyboard.current.iKey.wasPressedThisFrame)
                Debug.Log(save.exp);
        }


        #region ResourceRemover

        public bool TryRemoveResource(ResourceType resourceType, BigInteger value)
        {
            switch (resourceType)
            {
                case ResourceType.Exp:
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

            Save();
            return true;
        }

        public bool TryRemoveSkillPoint(uint skillPoint)
        {
            if (save.skillPoint < skillPoint) return false;

            save.skillPoint -= skillPoint;
            return true;
        }

        #endregion

        #region ResourceAdder

        public void AddResource(ResourceType resource, BigInteger value)
        {
            switch (resource)
            {
                case ResourceType.Exp:
                    save.exp += value;
                    break;
                case ResourceType.Gold:
                    save.gold += value;
                    break;
                case ResourceType.Diamond:
                    save.diamond += value;
                    break;
            }

            onChangeValue?.Invoke();
            Save();
        }

        public void AddSkillPoint(uint value)
        {
            save.skillPoint -= value;
            Save();
        }

        #endregion

        #region ResourceGetter

        public BigInteger GetResource(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Exp:
                    return save.exp;
                case ResourceType.Gold:
                    return save.gold;
                case ResourceType.Diamond:
                    return save.diamond;
            }

            return 0;
        }

        public uint GetSkillPoint()
            => save.skillPoint;

        public uint GetLevel()
            => save.level;

        #endregion

        public void Save()
        {
            save.SaveJson<ResourceSave>(fileName);
        }

        public void Load()
        {
            save = new ResourceSave();
            if (save.LoadJson<ResourceSave>(fileName) == false)
            {
                save.ResetData();
            }

            onChangeValue?.Invoke();
        }

    }

    public enum ResourceType
    {
        Exp,
        Gold,
        Diamond,
    }
}
