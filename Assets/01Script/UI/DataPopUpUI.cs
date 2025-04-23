using DKProject.SkillSystem;
using UnityEngine;

namespace DKProject.UI
{
    public class DataPopUpUI : TogglePanel
    {
        public override string Key => nameof(DataPopUpUI);

        [SerializeField] private DataPopUpPanel _dataPopUpPanelFirst, _dataPopUpPanelSecond;

        private void Start()
        {
            Close();
            _outButton.OnClickEvent += Close;
        }

        public void SetItem(SkillSO skillSO)
        {
            _dataPopUpPanelFirst.SetData(skillSO.icon, skillSO.skillName, skillSO.skillDescription, null, null);
        }

        public override void Open()
        {
            base.Open();
            ActiveElement(true);
        }

        public override void Close()
        {
            base.Close();
            ActiveElement(false);
        }
    }
}
