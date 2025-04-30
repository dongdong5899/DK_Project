using DKProject.EffectSystem;
using DKProject.SkillSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityStatus : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        protected Dictionary<EffectType, EffectSO> _statusDictionary = new();


        public void Initialize(Entity entity)
        {
            _entity = entity;

            //_entity.GetCompo<EntityHealth>().OnDeadEvent += AllRemoveStatus;
        }

        private void OnDestroy()
        {
            //_entity.GetCompo<EntityHealth>().OnDeadEvent += AllRemoveStatus;
        }
        public void StatusDictionaryInit(Dictionary<EffectSO, Effect> dictionary)
        {
            //_statusDictionary = dictionary.ToDictionary(kv => kv.Key, kv => (Effect)kv.Value.Clone());
        }
        //public virtual void AddStatus(StatusEnum statusEnum, bool isInfinity, float time = 0)
        //{
        //    StatusStat status = _statusDictionary[statusEnum];

        //    if (_statusDictionary[statusEnum].infiniteMode)
        //        return;

        //    if (isInfinity)
        //    {
        //        status.infiniteMode = true;
        //        status.lifeMode = false;
        //    }
        //    else
        //    {
        //        if (status is ILifeTimeStatus lifetimeStatus)
        //        {
        //            lifetimeStatus.SetLifeTime(time);
        //        }
        //    }

        //    if (status.isActive)
        //        return;

        //    _statusDictionary[statusEnum].StatusInit(_entity);
        //}

        //public virtual void RemoveStatus(StatusEnum statusEnum)
        //{
        //    if (!_statusDictionary.TryGetValue(statusEnum, out var status))
        //        return;
        //    if (!status.isActive)
        //        return;

        //    _statusDictionary[statusEnum].RemoveStatus();
        //}


        //private void AllRemoveStatus()
        //{
        //    foreach (var statusStat in _statusDictionary)
        //    {
        //        RemoveStatus(statusStat.Key);
        //    }
        //}
    }
}
