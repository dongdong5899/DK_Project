using DKProject.Stage;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class ChapterIndicator : MonoBehaviour
    {
        public event Action<ChapterSO> onSelectChapter;
        [SerializeField] private ChapterSelectButton _chapterSelectButtonPf;
        private ChapterListSO _chapterList;


        public void Init(ChapterListSO chapterList)
        {
            _chapterList = chapterList;

            _chapterList.chapterList.ForEach(chapter =>
            {
                ChapterSelectButton button = Instantiate(_chapterSelectButtonPf, transform);
                button.OnClickEvent += () => SelectChapter(chapter);
                button.Init(chapter);
            });

            SelectChapter(_chapterList.chapterList[0]);
        }

        public void SelectChapter(ChapterSO chapter)
        {
            onSelectChapter?.Invoke(chapter);
        }

    }
}
