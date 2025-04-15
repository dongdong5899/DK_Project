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
        //��ȭ�� �̱��� �Ἥ �ϴ°� �´µ� �� ����� �ؾ���
        //��ȭ �ý����� ��� �ҰųĿ� ���� ���ݾ� �ٸ�
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private LayoutGroup _bgLayout;
        [SerializeField] private RectTransform _iconRect;
        [SerializeField] private ResourceType _resourceType;

        private BigInteger _value = 0;

        private void OnEnable()
        {
            UpdateValue();
            ResourceManager.onChangeValue += UpdateValue;
        }

        private void OnDisable()
        {
            ResourceManager.onChangeValue -= UpdateValue;
        }

        private void Update()
        {
            if (Keyboard.current.oKey.wasPressedThisFrame)
                ResourceManager.AddResource(ResourceType.Gold, 3456);
        }

        public void UpdateValue()
        {
            _value = ResourceManager.GetResource(_resourceType);
            _text.SetText(_value.ParseNumber());
        }
    }
}
