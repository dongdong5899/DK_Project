using Doryu.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.EffectSystem
{
    [CreateAssetMenu(fileName = "EffectListSO", menuName = "SO/EffectListSO")]
    public class EffectListSO : ScriptableObject
    {
        [VisibleInspectorSO]
        [SerializeField] private List<EffectSO> _effectList;

        public List<EffectSO> GetList() => _effectList;
    }
}
