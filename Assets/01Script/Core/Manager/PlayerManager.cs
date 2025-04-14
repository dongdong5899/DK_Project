using DKProject.Entities.Players;
using UnityEngine;

namespace DKProject.Cores
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        public Player Player { get; private set; }

        protected override void CreateInstance()
        {
            Player = FindFirstObjectByType<Player>();
        }
    }
}