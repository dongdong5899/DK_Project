using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class UIEventController : MonoBehaviour
    {
        public List<UIEvent> UIEvents;

        private void Awake()
        {
            UIEvents = GetComponentsInChildren<UIEvent>().ToList();
        }

        public void PlayEvent()
        {
            UIEvents.ForEach(ui =>  ui.Play());
        }
    }
}