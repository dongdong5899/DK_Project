using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public class ParentSizeFitter : MonoBehaviour
    {
        [SerializeField] private ESizeDirectionFlag _direction;

        private RectTransform RectTrm => transform as RectTransform;

        public void SizeFit(Vector2 size)
        {
            if ((_direction & ESizeDirectionFlag.Heigth) != 0)
            {
                RectTrm.sizeDelta = new Vector2(RectTrm.sizeDelta.x, size.y);
            }

            if ((_direction & ESizeDirectionFlag.Width) != 0)
            {
                Debug.Log(size);
                RectTrm.sizeDelta = new Vector2(size.x, RectTrm.sizeDelta.y);
            }
        }
    }
}
