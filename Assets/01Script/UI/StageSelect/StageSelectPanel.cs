using DKProject.Core;
using DKProject.Stage;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DKProject.UI
{
    public class StageSelectPanel : ManagedUI, IToggleUI
    {
        [SerializeField] private ChapterListSO _chapterList;
        [SerializeField] private Button _outButton;
        private ChapterIndicator _chapterIndicator;
        private StageIndicator _stageIndicator;

        public override string Key => "StageSelectPanel";

        private void Awake()
        {
            _chapterIndicator = GetComponentInChildren<ChapterIndicator>();
            _stageIndicator = GetComponentInChildren<StageIndicator>();

            _chapterIndicator.onSelectChapter += _stageIndicator.OnSelectChapter;
            _chapterIndicator.Init(_chapterList);
            _outButton.OnClick += Close;
        }

        public void OnToggle(bool isOpen)
        {
            if (isOpen) Open();
            else Close();
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _outButton.gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _outButton.gameObject.SetActive(true);
        }
    }
}
