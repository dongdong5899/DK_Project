using DG.Tweening;
using DKProject.UI;
using UnityEngine;

namespace DKProject.UI
{
    public class UpgradeUI : UIBase, IToggleUI
    {
        public override string Key => nameof(UpgradeUI);

        private float _defaultYPos;

        private Sequence _moveSeq;

        private void Awake()
        {
            _defaultYPos = RectTransform.anchoredPosition.y;
        }

        public void Open()
        {
            if (_moveSeq != null && _moveSeq.IsActive()) _moveSeq.Kill();
            _moveSeq.Append(RectTransform.DOAnchorPosY(0, 0.2f));
        }

        public void Close()
        {
            if (_moveSeq != null && _moveSeq.IsActive()) _moveSeq.Kill();
            _moveSeq.Append(RectTransform.DOAnchorPosY(_defaultYPos, 0.2f));
        }
    }
}