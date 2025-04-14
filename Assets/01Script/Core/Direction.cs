using System;
using UnityEngine;

namespace DKProject.Core
{
    public static class Direction
    {
        public static Vector2[] directionVector = new Vector2[5]
            {
                Vector2.zero,
                Vector2.up,
                Vector2.left,
                Vector2.down,
                Vector2.right,
            };

        public static Vector2 GetDirectionVector(this EDirection direction)
            => directionVector[(int)direction];
    }

    public enum EDirection
    {
        None = 0,
        Up = 1,
        Left = 2,
        Down = 3,
        Right = 4
    }

    public enum ESizeDirection
    {
        None = 0,
        Width = 1,
        Heigth = 2
    }

    [Flags]
    public enum ESizeDirectionFlag
    {
        None = 0,
        Width = 1,
        Heigth = 2
    }
}
