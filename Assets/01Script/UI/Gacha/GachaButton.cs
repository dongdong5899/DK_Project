using DKProject.Core;
using DKProject.UI;
using UnityEngine;

namespace DKProject
{
    public class GachaButton : MonoBehaviour
    {
        [SerializeField] private int _gachaCount;

        private Button _button;
        private int _singleGachaCost = 30;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.OnClickEvent += ClickButton;
        }

        private void ClickButton()
        {
            if (ResourceData.TryRemoveResource(ResourceType.Diamond, _gachaCount * _singleGachaCost))
            {
                // ��í ���â ȣ��
            }
            else
            {
                Debug.Log("none dia");
            }
        }
    }
}
