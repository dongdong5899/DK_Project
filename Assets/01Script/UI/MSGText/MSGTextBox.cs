using DG.Tweening;
using DKProject.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class MSGTextBox : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _tmp;

        private EDirection _textOutDirection;
        private EDirection _textMoveDirection;
        private float _textBoxOutTime;
        private float _textBoxLifeTime;

        private Tween _textOutTween;

        private RectTransform BGRect => transform.GetChild(0) as RectTransform;
        private RectTransform RectTrm => transform as RectTransform;

        public void SetIcon(Sprite sprite)
        {
            if (sprite == null)
            {
                _icon.gameObject.SetActive(false);
                return;
            }
            _icon.gameObject.SetActive(true);
            _icon.sprite = sprite;
        }

        public void SetText(string text)
        {
            if (text == string.Empty)
            {
                _tmp.gameObject.SetActive(false);
                return;
            }
            _tmp.gameObject.SetActive(true);
            _tmp.SetText(text);
        }

        public void Init(EDirection textOutDirection, EDirection textMoveDirection, float textBoxOutTime, float textBoxLifeTime)
        {
            _textOutDirection = textOutDirection;
            _textMoveDirection = textMoveDirection;
            _textBoxOutTime = textBoxOutTime;
            _textBoxLifeTime = textBoxLifeTime;

            if ((int)textOutDirection % 2 == 0)
            {
                float width = BGRect.sizeDelta.x;
                if (textOutDirection == EDirection.Left) width *= -1;

                BGRect.anchoredPosition = new Vector2(width, 0);
                _textOutTween = BGRect.DOAnchorPosX(0, textBoxOutTime);
            }
            else
            {
                float height = BGRect.sizeDelta.x;
                if (textOutDirection == EDirection.Down) height *= -1;

                BGRect.anchoredPosition = new Vector2(0, height);
                _textOutTween = BGRect.DOAnchorPosY(0, textBoxOutTime);
            }

        }
    }
}
