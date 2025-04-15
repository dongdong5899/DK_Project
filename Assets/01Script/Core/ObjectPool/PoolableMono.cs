using System;
using UnityEngine;

namespace DKProject.Cores.Pool
{
    public interface IPoolable
    {
        public GameObject GameObject { get; }
        public Enum PoolEnum { get; }  // ���⸸ ����
        public void OnPop();
        public void OnPush();
    }
}
