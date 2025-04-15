using DKProject.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class LayoutPeddingSetter : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.LayoutGroup _layoutGroup;
        [SerializeField] private EPeddingDirection _peddingDirection;
        [SerializeField] private ESizeDirection _sizeDirection;
        [Space]
        [SerializeField] private int _multiplyOffset = 1;
        [SerializeField] private int _addOffset = 0;


        public void SetPedding(Vector2 size)
        {
            int calcuratedSize = 0;

            if ((_sizeDirection & ESizeDirection.Width) != 0)
            {
                calcuratedSize = (int)size.x;
            }

            if ((_sizeDirection & ESizeDirection.Heigth) != 0)
            {
                calcuratedSize = (int)size.y;
            }

            calcuratedSize *= _multiplyOffset;
            calcuratedSize += _addOffset;

            switch (_peddingDirection)
            {
                case EPeddingDirection.Left:
                    _layoutGroup.padding.left = calcuratedSize;
                    break;
                case EPeddingDirection.Right:
                    _layoutGroup.padding.right = calcuratedSize;
                    break;
                case EPeddingDirection.Top:
                    _layoutGroup.padding.top = calcuratedSize;
                    break;
                case EPeddingDirection.Bottom:
                    _layoutGroup.padding.bottom = calcuratedSize;
                    break;
            }
        }
    }

    public enum EPeddingDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }
}

