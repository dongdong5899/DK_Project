using DKProject.Stage;
using UnityEngine;

namespace DKProject.UI
{
    public class StageSelectPanel : UIBase, IToggleUI
    {
        [SerializeField] private ChapterListSO _chapterList;
        private ChapterIndicator _chapterIndicator;
        private StageIndicator _stageIndicator;
     
        public override string Key => "StageSelectPanel";

        private void Awake()
        {
            _chapterIndicator = GetComponentInChildren<ChapterIndicator>();
            _stageIndicator = GetComponentInChildren<StageIndicator>();

            _chapterIndicator.onSelectChapter += _stageIndicator.OnSelectChapter;
            _chapterIndicator.Init(_chapterList);
        }


        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }
    }
}
