using DKProject.StatSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityStat : MonoBehaviour, IEntityComponent
    {
        public List<StatElement> _overrideStatElementList;
        public StatBaseSO _baseStatSO;
        public StatDictionary StatDictionary { get; private set; }

        public void Initialize(Entity entity)
        {
            StatDictionary = new StatDictionary(_overrideStatElementList, _baseStatSO);
        }
    }
}
