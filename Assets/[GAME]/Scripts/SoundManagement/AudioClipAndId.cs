using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts.SoundManagement
{
    [Serializable]
    public struct AudioClipAndId
    {
        [HorizontalGroup]
        public AudioClip audioClip;

        [HorizontalGroup]
        public string clipId;
    }
}