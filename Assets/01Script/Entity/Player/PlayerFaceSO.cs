using System;
using UnityEngine;

namespace DKProject.Entities.Players
{
    public enum EPlayerFaceType
    {
        Default,
        Happy,
        Sad,
        Angry,
        Surprise
    }

    [CreateAssetMenu(fileName = "PlayerFace", menuName = "SO/PlayerFace")]
    public class PlayerFaceSO : ScriptableObject
    {
        public EPlayerFaceType faceType;
        public Sprite sprite;
    }
}
