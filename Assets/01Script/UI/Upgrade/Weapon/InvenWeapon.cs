using UnityEngine;

namespace DKProject
{
    public class InvenWeapon : InvenSlot
    {
        protected override void HandleClickEvent()
        {
            Debug.Log("Weapon");
        }
    }
}
