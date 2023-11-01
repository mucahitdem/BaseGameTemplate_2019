using System;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts
{
    [Serializable]
    public struct PosAndIsFullFlag
    {
        public Transform targetPos;
        public bool isFull;
    }
}