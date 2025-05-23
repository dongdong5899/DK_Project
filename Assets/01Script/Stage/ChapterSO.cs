using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Chapter
{
    [CreateAssetMenu(menuName = "SO/Stage/ChapterSO")]
    public class ChapterSO : ScriptableObject
    {
        public string chapterName;
        public Sprite chapterBGSprite;
        public List<StageSO> stageList;
    }
}
