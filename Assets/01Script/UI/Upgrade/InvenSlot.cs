using DKProject.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Button = DKProject.UI.Button;

namespace DKProject
{
    public abstract class InvenSlot : MonoBehaviour
    {
        [SerializeField] protected Image _icon;
        protected Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.OnClickEvent += HandleClickEvent;
        }

        protected abstract void HandleClickEvent();

        protected virtual void OnDestroy()
        {
            _button.OnClickEvent -= HandleClickEvent;
        }
    }
}
