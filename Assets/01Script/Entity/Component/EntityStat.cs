using DKProject.StatSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityStat : MonoBehaviour, IEntityComponent
    {
        public List<StatElement> _overrideStatElementList;
        public StatBaseSO _statBaseSO;
        public StatDictionary StatDictionary { get; private set; }

        public void Initialize(Entity entity)
        {
            StatDictionary = new StatDictionary(_overrideStatElementList, _statBaseSO);
        }
    }
}
