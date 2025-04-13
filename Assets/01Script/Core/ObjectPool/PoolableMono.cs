using System;
using UnityEngine;

namespace DKProject.Cores.Pool
{
    public interface IPoolable
    {
        public GameObject GameObject { get; set; }
        public Enum PoolEnum { get; set; }  // 여기만 수정
        public void Init();
    }
}
