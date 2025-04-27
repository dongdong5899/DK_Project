using DKProject.SkillSystem;
using UnityEngine;

namespace DKProject.Combat
{
    public class ItemSO : ScriptableObject
    {
        [Header("Description")]
        public string itemClassName;
        public string itemName;
        public Sprite icon;
        public Rank itemRank;
        public ItemType itemType;
        [TextArea]
        public string itemDescription;
    }
}
