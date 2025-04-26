using Doryu.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Combat
{
    public class ItemListSO : ScriptableObject
    {
        [VisibleInspectorSO]
        [SerializeField] private List<ItemSO> _itemList;

        public List<ItemSO> GetList() => _itemList;
    }
}
