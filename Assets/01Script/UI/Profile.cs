using DKProject.Core;
using TMPro;
using UnityEngine;

namespace DKProject.UI
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _combatValue;

        [SerializeField] private Slider _expSlider;
        [SerializeField] private Slider _hpSlider;

        private void Awake()
        {
            ResourceData.OnChangeValue += UpdateValue;
        }

        private void OnDestroy()
        {
            ResourceData.OnChangeValue -= UpdateValue;
        }

        public void UpdateValue()
        {
            _nameText.SetText($"{PlayerManager.Instance.GetLevel()}. 레오우야");
            _expSlider.SetAmount((float)PlayerManager.Instance.GetExp() / PlayerManager.Instance.NextRequireExp);
        }
    }
}
 