using DKProject.Chapter;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class ChapterIndicator : MonoBehaviour
    {
        public event Action<ChapterSO, int> onSelectChapter;
        [SerializeField] private ChapterSelectButton _chapterSelectButtonPf;
        private ChapterListSO _chapterList;


        public void Init(ChapterListSO chapterList)
        {
            _chapterList = chapterList;

            for(int i = 0; i < _chapterList.chapterList.Count; i++)
            {
                int chapterindex = i;
                ChapterSO chapter = _chapterList.chapterList[i];
                ChapterSelectButton button = Instantiate(_chapterSelectButtonPf, transform);
                button.OnClickEvent += () => SelectChapter(chapter, chapterindex);
                button.Init(chapter);
            }

            SelectChapter(_chapterList.chapterList[0], 0);
        }

        public void SelectChapter(ChapterSO chapter, int chapterIndex)
        {
            onSelectChapter?.Invoke(chapter, chapterIndex);
        }

    }
}
