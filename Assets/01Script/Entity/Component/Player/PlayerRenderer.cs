using DKProject.Entities.Players;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class PlayerRenderer : EntityRenderer
    {
        [SerializeField] private SpriteRenderer _faceRenderer;
        [SerializeField] private List<PlayerFaceSO> _faceList;
        private Dictionary<EPlayerFaceType, Sprite> _faceDictionary;

        public override void Initialize(Entity entity)
        {
            base.Initialize(entity);
            _faceDictionary = new Dictionary<EPlayerFaceType, Sprite>();
            foreach (PlayerFaceSO PlayerFace in _faceList)
            {
                _faceDictionary.Add(PlayerFace.faceType, PlayerFace.sprite);
            }
            SetFace(_faceList[0].faceType);
        }

        public void SetFace(EPlayerFaceType faceType)
        {
            _faceRenderer.sprite = _faceDictionary[faceType];
        }
    }
}