using Doryu.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Core.Pool
{
    [CreateAssetMenu(menuName = "SO/Pool/PoolList")]
    public class PoolListSO : ScriptableObject
    {
        [VisibleInspectorSO]
        [SerializeField] private List<PoolingItemSO> _list;

        public List<PoolingItemSO> GetList() => _list;
    }
}

