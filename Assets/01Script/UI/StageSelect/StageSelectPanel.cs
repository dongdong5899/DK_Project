using DKProject.Stage;
using UnityEngine;

namespace DKProject.UI
{
    public class StageSelectPanel : OutAreaToggleUI
    {
        [SerializeField] private ChapterListSO _chapterList;
        private ChapterIndicator _chapterIndicator;
        private StageIndicator _stageIndicator;

        public override string Key => "StageSelectPanel";

        protected override void Awake()
        {
            base.Awake();
            _chapterIndicator = GetComponentInChildren<ChapterIndicator>();
            _stageIndicator = GetComponentInChildren<StageIndicator>();

            _chapterIndicator.onSelectChapter += _stageIndicator.OnSelectChapter;
            _chapterIndicator.Init(_chapterList);
            _outButton.OnClickEvent += Close;
            Close();
        }

        public override void Open()
        {
            ActiveElement(true);
        }

        public override void Close()
        {
            ActiveElement(false);
        }
    }
}
