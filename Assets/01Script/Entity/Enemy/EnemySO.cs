using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.Entities.Enemies
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public EnemyPoolingType enemyType;
        public Sprite enemyIcon;
        public string enemyName;
        public string enemyExplain;
    }
}
