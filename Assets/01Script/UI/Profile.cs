using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _expFill;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _combatValue;

        [Space]
        [SerializeField] private RectTransform _BGRect;
        [SerializeField] private UnityEngine.UI.LayoutGroup _BGLayoutGroup;

        public void SetBGPosition(Vector2 size)
        {
            int width = (int)size.y / 2;
            _BGRect.offsetMin = new Vector2(width, 0);
            _BGLayoutGroup.padding.left = width + 10;
            StartCoroutine(DelayForceRebuild());
        }

        private IEnumerator DelayForceRebuild()
        {
            yield return null;
            LayoutRebuilder.ForceRebuildLayoutImmediate(_BGRect);
        }
    }
}
