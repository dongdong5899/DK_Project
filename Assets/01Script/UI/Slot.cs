using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public abstract class Slot : MonoBehaviour
    {
        [SerializeField] protected Image _icon;

        public void SetIcon(Sprite sprite)
        {
            if (sprite == null) 
            {
                RemoveIcon();
                return;
            }

            if (_icon.gameObject.activeSelf == false)
                _icon.gameObject.SetActive(true);

            _icon.sprite = sprite;
        }

        public  void RemoveIcon()
        {
            _icon.gameObject.SetActive(false);
            _icon.sprite = null;
        }
    }
}
