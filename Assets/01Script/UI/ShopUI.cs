using UnityEngine;

namespace DKProject.UI
{
    public class ShopUI : MonoBehaviour, IWindowPanel
    {
        private CanvasGroup _canvasGruop;
        [SerializeField] private GameObject _outButton;

        private void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
            Close();
        }

        public void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.SetActive(false);
        }

        public void Open()
        {
            _canvasGruop.alpha = 1;
            _canvasGruop.blocksRaycasts = true;
            _canvasGruop.interactable = true;
            _outButton.SetActive(true);
        }
    }
}
