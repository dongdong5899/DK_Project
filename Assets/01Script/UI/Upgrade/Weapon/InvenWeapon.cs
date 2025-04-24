using UnityEngine;

namespace DKProject
{
    public class InvenWeapon : InvenSlot
    {
        public override void UpdateLevel()
        {

        }

        protected override void HandleClickEvent()
        {
            Debug.Log("Weapon");
        }
    }
}
