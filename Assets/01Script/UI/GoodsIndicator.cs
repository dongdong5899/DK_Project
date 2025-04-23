using DKProject.Core;
using System.Numerics;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace DKProject.UI
{
    public class GoodsIndicator : MonoBehaviour
    {
        //재화는 싱글톤 써서 하는게 맞는데 뭐 ㅈ대로 해야지
        //재화 시스템을 어떻게 할거냐에 따라서 조금씩 다름
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private RectTransform _iconRect;
        [SerializeField] private ResourceType _resourceType;

        private BigInteger _value = 0;

        private void OnEnable()
        {
            UpdateValue();
            ResourceManager.OnChangeValue += UpdateValue;
        }

        private void OnDisable()
        {
            ResourceManager.OnChangeValue -= UpdateValue;
        }

        public void UpdateValue()
        {
            _value = ResourceManager.GetResource(_resourceType);
            _text.SetText(_value.ParseNumber());
        }
    }
}
