using DKProject.UI;
using UnityEngine;

namespace DKProject
{
    public class SkillUpgradePanel : TogglePanel
    {
        public override string Key => nameof(SkillUpgradePanel);

        protected override void Awake()
        {
            base.Awake();
            Close();
        }

        public override void Open()
        {
            ActiveElement(true);
        }

        public override void Close()
        {
            ActiveElement(false);
        }
    }
}
