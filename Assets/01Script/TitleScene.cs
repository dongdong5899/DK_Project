using DKProject.Core;
using DKProject.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace DKProject.Title
{
    public class TitleScene : MonoBehaviour
    {
        private LoadingPanel _loadingPanel;

        private void Awake()
        {
            _loadingPanel = FindAnyObjectByType<LoadingPanel>();
        }

        private void Update()
        {
            if(Touchscreen.current.press.isPressed)
            {
                _loadingPanel.Open();
                _loadingPanel.onCompleteOpen += LoadScene;
            }
        }

        private void LoadScene()
        {
            AsyncOperation loadHandle = SceneManager.LoadSceneAsync(SceneName.ingameScene);
            loadHandle.completed += handle => _loadingPanel.Close();
            _loadingPanel.onCompleteOpen -= LoadScene;
        }
    }
}
