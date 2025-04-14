using Doryu.JBSave;
using System.IO;
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

        public void AddExp(ulong value)
        {
            save.exp += value;
            Save();
        }


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
                Debug.Log("¹Ö¹Ö¹Ö");
            }
            Debug.Log(save);
        }
    }
}
