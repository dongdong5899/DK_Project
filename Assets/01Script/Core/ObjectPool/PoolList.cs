using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Cores.Pool
{
    [CreateAssetMenu(menuName = "SO/Pool/PoolList")]
    public class PoolList : ScriptableObject
    {
        [SerializeField] private List<PoolingItemSO> _list;

        public List<PoolingItemSO> GetList() => _list;
    }
}

