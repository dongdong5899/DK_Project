using System;
using UnityEngine;

namespace DKProject.Cores.Pool
{
    public interface IPoolable
    {
        public GameObject GameObject { get; set; }
        public Enum PoolEnum { get; set; }  // ���⸸ ����
        public void Init();
    }
}
