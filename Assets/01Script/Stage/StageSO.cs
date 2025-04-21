using System.Numerics;
using UnityEngine;

namespace DKProject.Stage
{
    [CreateAssetMenu(menuName = "SO/Stage/StageSO")]
    public class StageSO : ScriptableObject
    {
        public string stageName;
        public Sprite stageBGSprite;
        public ulong recommendCombat;
        public GameObject stagePrefab;
    }
}
