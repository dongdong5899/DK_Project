using DKProject.SkillSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = DKProject.UI.Button;

namespace DKProject
{
    public abstract class InvenSlot : MonoBehaviour
    {
        [SerializeField] protected Image _icon;
        [SerializeField] protected TextMeshProUGUI _level, _price;
        protected Button _button;

        public InvenSlot PrevSlot { get; private set; }
        public InvenSlot NextSlot { get; private set; }
        public SkillSO SkillSO { get; private set; }

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.OnClickEvent += HandleClickEvent;
        }

        public void Init(InvenSlot prev, InvenSlot next, SkillSO skillSO)
        {
            PrevSlot = prev;
            NextSlot = next;
            SkillSO = skillSO;
            _icon.sprite = skillSO.icon;
            UpdateLevel();
        }

        protected abstract void HandleClickEvent();

        public abstract void UpdateLevel();

        protected virtual void OnDestroy()
        {
            _button.OnClickEvent -= HandleClickEvent;
        }
    }
}
