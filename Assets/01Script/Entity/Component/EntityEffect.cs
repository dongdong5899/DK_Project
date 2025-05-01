using DG.Tweening;
using DKProject.EffectSystem;
using DKProject.Entities.Players;
using DKProject.SkillSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityEffect : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        private List<Effect> _effects;
        [SerializeField] private EffectListSO _effectSOList;

        private Dictionary<EffectSO, Effect> _effectClassDictionary = new();
        private EntityStat _entityStat;
        public void Initialize(Entity entity)
        {
            _entity = entity;
            _effects = new List<Effect>();
            _entityStat = _entity.GetCompo<EntityStat>();
            foreach (EffectSO effectSO in _effectSOList.GetList())
            {
                _effectClassDictionary.Add(effectSO, effectSO.GetEffect(_entity));
            }
        }

        private void Update()
        {
            for (int i = 0; i < _effects.Count; i++) 
            {
                Effect effect = _effects[i];
                effect.Update();
            }
        }


        public void ApplyEffect(EffectType effectType)
        {
            foreach (var kvp in _effectClassDictionary)
            {
                if (kvp.Key.effectType == effectType)
                {
                    Effect effect = kvp.Value;
                    _effects.Add(effect);
                    effect.ApplyEffect(_entityStat);
                    if (kvp.Key.isEffectTime)
                    {
                        DOVirtual.DelayedCall(kvp.Key.effectTime, () =>
                        {
                            RemoveEffect(kvp.Key.effectType);
                        });
                    }
                    break;
                }
            }
        }

        public void RemoveEffect(EffectType effectType)
        {
            foreach(Effect effect in _effects)
            {
                if(effect.EffectSO.effectType == effectType)
                {
                    _effects.Remove(effect);
                    effect.RemoveEffect(_entityStat);
                }
            }
        }

    }
}
