using System.Numerics;
using UnityEngine;

namespace DKProject.Stage
{
    [CreateAssetMenu(menuName = "SO/StageSO")]
    public class StageSO : ScriptableObject
    {
        public string stageName;
        public ulong recommendCombat;
        public GameObject stagePrefab;
    }
}
