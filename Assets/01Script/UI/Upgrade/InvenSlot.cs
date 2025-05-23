using DKProject.Combat;
using DKProject.Core;
using DKProject.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = DKProject.UI.Button;

namespace DKProject
{
    public abstract class InvenSlot : MonoBehaviour
    {
        [SerializeField] protected Image _icon;
        [SerializeField] protected TextMeshProUGUI _level;
        protected Button _button;

        public InvenSlot PrevSlot { get; private set; }
        public InvenSlot NextSlot { get; private set; }
        public ItemSO ItemSO { get; private set; }

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.OnClickEvent += HandleClickEvent;
        }

        public void Init(InvenSlot prev, InvenSlot next, ItemSO itemSO)
        {
            Debug.Log("Init");
            PrevSlot = prev;
            NextSlot = next;
            ItemSO = itemSO;
            _icon.sprite = itemSO.icon;
            UpdateLevel();
        }

        protected void HandleClickEvent()
        {
            DataPopUpUI dataPopUpUI = UIManager.Instance.OpenUI(nameof(DataPopUpUI)) as DataPopUpUI;
            dataPopUpUI.SetItem(this);
        }

        public abstract void UpdateLevel();

        protected virtual void OnDestroy()
        {
            _button.OnClickEvent -= HandleClickEvent;
        }
    }
}
