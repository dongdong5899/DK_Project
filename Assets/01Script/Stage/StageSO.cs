using DKProject.Core.Pool;
using DKProject.Entities.Enemies;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DKProject.Chapter
{
    [CreateAssetMenu(menuName = "SO/Stage/StageSO")]
    public class StageSO : ScriptableObject
    {
        public string stageName;
        public Sprite stageBGSprite;
        public ulong recommendCombat;
        public AssetReference stageRef;
        [Space]
        public List<EnemySO> appearingEnemy;      //TODO: Change to spawn enemy with ratio
    }
}
