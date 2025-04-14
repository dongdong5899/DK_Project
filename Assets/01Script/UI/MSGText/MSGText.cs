using DKProject.Core;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class MSGText : MonoBehaviour
    {
        [SerializeField] private MSGTextBox _textBoxPf;

        [Space]
        [SerializeField] private EDirection _peddingDirection;
        [SerializeField] private float _pedding;

        [Space]
        [SerializeField] private EDirection _textMoveDirection;
        [SerializeField] private float _textBoxOutTime;
        [SerializeField] private float _textBoxMoveDelay;
        [SerializeField] private float _textBoxLifeTime;

        [Space]
        [SerializeField] private int _poolCount;
        private Stack<MSGTextBox> _textBoxPool;


        private void Init()
        {
            _textBoxPool = new Stack<MSGTextBox>();
        
            for(int i = 0; i < _poolCount; i++)
            {
                MSGTextBox textBox = Instantiate(_textBoxPf, transform);
                textBox.Init(_peddingDirection, _textMoveDirection, _textBoxOutTime, _textBoxLifeTime);

                _textBoxPool.Push(textBox);
            }
        }

        public void GenerateTextBox(Sprite icon, string text)
        {
            if (icon == null && text == string.Empty) return;

            MSGTextBox textBox = Instantiate(_textBoxPf, transform);
            textBox.SetIcon(icon);
            textBox.SetText(text);


        }
    }
}
