using System;
using UnityEngine;

namespace DKProject.UI.Events
{

    [Serializable]
    public abstract class PlayEvent : UIEvent
    {
        public abstract void Play();
    }
}
