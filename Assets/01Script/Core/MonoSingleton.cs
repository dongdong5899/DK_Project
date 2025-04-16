using System;
using UnityEngine;

namespace DKProject.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
    {
        private static T _Instance;
        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindFirstObjectByType<T>();
                    if (_Instance == null)
                    {
                        //없으면 만들기
                        Type singleton = typeof(T);
                        GameObject singletonObj = new GameObject($"{singleton.ToString()}", singleton);
                        _Instance = singletonObj.GetComponent<T>();
                    }
                    _Instance.CreateInstance();
                }
                return _Instance;
            }
        }

        protected virtual void CreateInstance() { }
    }
}