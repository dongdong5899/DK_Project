using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class Slider : MonoUI
    {
        [SerializeField] private Image _slider;

        public void SetAmount(float amount)
        {
            _slider.fillAmount = amount;
        }
    }
}
