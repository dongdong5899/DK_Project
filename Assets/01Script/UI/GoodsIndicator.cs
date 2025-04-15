using DKProject.Core;
using System.Numerics;
using System.Text;
using TMPro;
using UnityEngine;
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
            ResourceManager.Instance.onChangeValue += UpdateValue;
        }

        private void OnDisable()
        {
            ResourceManager.Instance.onChangeValue -= UpdateValue;
        }

        public void UpdateValue()
        {
            _value = ResourceManager.Instance.GetResource(_resourceType);
            _text.SetText(_value.ParseNumber());
        }
    }
}
