using DG.Tweening;
using DKProject.UI;
using UnityEngine;

namespace DKProject.UI
{
    public class UpgradeUI : TogglePanel, IToggleUI
    {
        public override string Key => nameof(UpgradeUI);

        private float _defaultYPos;

        private Sequence _moveSeq;

        protected override void Awake()
        {
            base.Awake();
            _defaultYPos = RectTransform.anchoredPosition.y;
        }

        public override void Open()
        {
            base.Open();
            if (_moveSeq != null && _moveSeq.IsActive()) _moveSeq.Kill();
            _moveSeq.Append(RectTransform.DOAnchorPosY(0, 0.2f));
        }

        public override void Close()
        {
            base.Close();
            if (_moveSeq != null && _moveSeq.IsActive()) _moveSeq.Kill();
            _moveSeq.Append(RectTransform.DOAnchorPosY(_defaultYPos, 0.2f));
        }
    }
}