using System;
using UnityEngine;

namespace DKProject.Core.Pool
{
    public interface IPoolable
    {
        public GameObject GameObject { get; }
        public Enum PoolEnum { get; }  // 여기만 수정
        public void OnPop();
        public void OnPush();
    }
}
