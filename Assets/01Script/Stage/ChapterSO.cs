using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Stage
{
    [CreateAssetMenu(menuName = "SO/Stage/ChapterSO")]
    public class ChapterSO : ScriptableObject
    {
        public string chapterName;
        public List<StageSO> stageList;
    }
}
