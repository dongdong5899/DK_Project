using UnityEngine;

namespace DKProject.Chapter
{
    public class Stage : MonoBehaviour
    {
        private EnemyGenerator _enemyGenerator;


        public void Init(StageSO stage)
        {
            _enemyGenerator = GetComponent<EnemyGenerator>();
            _enemyGenerator.Init(stage);
        }
    }
}
