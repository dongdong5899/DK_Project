using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Stage
{
    [CreateAssetMenu(menuName = "SO/ChapterSO")]
    public class ChapterSO : ScriptableObject
    {
        public List<StageSO> stageList;
    }
}
