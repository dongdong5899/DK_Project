using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public abstract class Slot : MonoBehaviour
    {
        [SerializeField] protected Image _icon;

        public void SetIcon(Sprite sprite)
        {
            bool isNull = sprite == null;
            if (_icon.gameObject.activeSelf == isNull)
                _icon.gameObject.SetActive(!isNull);

            _icon.sprite = sprite;
        }
    }
}
