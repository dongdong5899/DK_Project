using DKProject.Core;
using DKProject.UI;
using Doryu.JBSave;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace DKProject.Chapter
{
    public class ChapterManager : MonoSingleton<ChapterManager>
    {
        [SerializeField] private ChapterListSO _chapterInfo;
        private ChapterSave _chapterSave;
        private int _progressChapter;
        private int _stageProcess;

        private int _currentChapterIndex;
        private int _currentStageIndex;

        private StageSO _currentStage;
        private AsyncOperationHandle<GameObject> _loadHandle;
        private LoadingPanel loadingPanel;

        private const string fileName = "Chapter";

        protected void Awake()
        {
            if (Instance != this) Destroy(gameObject);
            else
            {
                DontDestroyOnLoad(gameObject);
                loadingPanel = UIManager.Instance.GetUI<LoadingPanel>("LoadingPanel");
            }
        }

        public void LoadStage(int chapter, int stage)
        {
            if (chapter != _currentChapterIndex && _loadHandle.IsValid())
                _loadHandle.Release();

            _currentChapterIndex = chapter;
            _currentStageIndex = stage;

            loadingPanel.Open();
            loadingPanel.onCompleteOpen += LoadStageEvent;
        }

        public void LoadStageEvent()
        {
            AsyncOperation sceneChange = SceneManager.LoadSceneAsync(SceneName.ingameScene);
            sceneChange.completed += operation =>
            {
                _currentStage = _chapterInfo.chapterList[_currentChapterIndex].stageList[_currentStageIndex];

                _loadHandle = _currentStage.stageRef.InstantiateAsync();
                _loadHandle.Completed += handle => loadingPanel.Close();
            };
        }


        private void Save()
        {
            _chapterSave.chapterProgress = _progressChapter;
            _chapterSave.currentStage = _currentStageIndex;
            _chapterSave.OnSaveData(fileName);
        }

        private void Load()
        {
            _chapterSave = new ChapterSave();

            if (_chapterSave.LoadJson<ChapterSave>(fileName) == false)
                _chapterSave.ResetData();

            _chapterSave.OnLoadData(_chapterSave);
            _progressChapter = _chapterSave.chapterProgress;
        }
    }
}
