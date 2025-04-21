using System;
using UnityEngine;

namespace DKProject.UI.Events
{
    [Serializable]
    public abstract class UIEvent
    {
        protected MonoUI _monoUI;

        public virtual void EventInit(MonoUI monoUI)
        {
            _monoUI = monoUI;
        }
        public abstract void EventPlay();
    }
}
