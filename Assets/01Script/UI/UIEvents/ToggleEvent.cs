using System;
using UnityEngine;

namespace DKProject.UI.Events
{
    [Serializable]
    public abstract class ToggleEvent : UIEvent
    {
        public abstract void Enable();
        public abstract void Disable();
    }
}
