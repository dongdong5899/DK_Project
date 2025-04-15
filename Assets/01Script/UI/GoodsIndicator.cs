using DKProject.Core;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class GoodsIndicator : MonoBehaviour
    {
        //재화는 싱글톤 써서 하는게 맞는데 뭐 ㅈ대로 해야지
        //재화 시스템을 어떻게 할거냐에 따라서 조금씩 다름
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private LayoutGroup _bgLayout;
        [SerializeField] private RectTransform _iconRect;

        private ulong _value = 0;

        private void Awake()
        {
            SetValue(9347483721123);
        }

        public void AddValue(ulong value)
            => SetValue(_value + value);

        public void SetValue(ulong value)
        {
            _value = value;
            _text.SetText(value.ParseNumber());
        }

        public void ChangeScale(Vector2 scale)
        {
            int pedding = _bgLayout.padding.right;

            int height = Mathf.RoundToInt(scale.y);
            float size = height - pedding * 2;

            _bgLayout.padding.left = (height + (pedding * 2));
            _iconRect.sizeDelta = new Vector2(size, size);
            _text.rectTransform.sizeDelta = new Vector2(_text.rectTransform.sizeDelta.x, size);
            _iconRect.anchoredPosition = new Vector2((height / 2) + pedding, 0);
        }
    }
}
