using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Chapter
{
    [CreateAssetMenu (menuName = "SO/Stage/ChapterList")]
    public class ChapterListSO : ScriptableObject
    {
        public List<ChapterSO> chapterList;
    }
}
