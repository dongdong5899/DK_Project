using Doryu.JBSave;
using System.Collections;
using System.IO;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Core
{
    public class ResourceManager : MonoBehaviour
    {
        public ResourceSave save;

        private string fileName = "Resource";


        public void Start()
        {
            Load();
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
                Save();

            if (Keyboard.current.oKey.wasPressedThisFrame)
                AddExp(10);

            if (Keyboard.current.iKey.wasPressedThisFrame)
                Debug.Log(save.exp);
        }


        public void AddExp(BigInteger value)
        {
            save.exp += value;
            Save();
        }


        public BigInteger GetResource(ResourceType resourceType)
        {
            switch(resourceType)
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
        }
    }

    public enum ResourceType
    {
        Exp,
        Gold,
        Diamond,
    }
}
