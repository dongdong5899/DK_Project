using DKProject.Core;
using System.Collections;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _combatValue;

        [SerializeField] private Slider _expSlider;
        [SerializeField] private Slider _hpSlider;

        private void OnEnable()
        {
            ResourceManager.onChangeValue += UpdateValue;
        }

        private void OnDisable()
        {
            ResourceManager.onChangeValue -= UpdateValue;
        }

        public void UpdateValue()
        {
            _nameText.SetText($"{ResourceManager.GetLevel()}. 레오우야");
            ResourceManager.GetResource(ResourceType.EXP);
        }
    }
}
