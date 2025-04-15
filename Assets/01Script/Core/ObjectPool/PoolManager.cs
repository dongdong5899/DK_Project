using System;
using System.Collections.Generic;
using UnityEngine;
using Doryu.CustomAttributes;

namespace DKProject.Cores.Pool
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private Dictionary<PoolingKey, Pool<IPoolable>> _poolDictionary
        = new Dictionary<PoolingKey, Pool<IPoolable>>();

        [VisibleInspectorSO]
        public PoolListSO poolListSO;

        private void Awake()
        {
            foreach (PoolingItemSO item in poolListSO.GetList())
            {
                CreatePool(item);
            }
        }

        private void CreatePool(PoolingItemSO item)
        {
            var key = item.PoolObj.PoolEnum;
            var pool = new Pool<IPoolable>(item.PoolObj, new PoolingKey(key), transform, item.poolCount);
            _poolDictionary.Add(new PoolingKey(key), pool);
        }

        public IPoolable Pop(Enum type)
        {
            PoolingKey key = new PoolingKey(type);

            if (!_poolDictionary.ContainsKey(key))
            {
                Debug.LogError($"Prefab does not exist on pool : {key}");
                return null;
            }

            var item = _poolDictionary[key].Pop();
            item.Init();
            return item;
        }

        public void Push(IPoolable obj, bool resetParent = false)
        {
            if (resetParent)
                obj.GameObject.transform.SetParent(transform);
            _poolDictionary[new PoolingKey(obj.PoolEnum)].Push(obj);
        }

    }
}



