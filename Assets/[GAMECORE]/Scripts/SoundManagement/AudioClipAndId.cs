using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GAME.Scripts.SoundManagement
{
    [Serializable]
    public class AudioClipAndId
    {
        [FoldoutGroup("Data"), GUIColor(0.3f, 0.8f, 0.8f)]
        public AudioClip audioClip;

        [FoldoutGroup("Data"), GUIColor(0.3f, 0.8f, 0.8f)]
        public string clipAddress;

        [FoldoutGroup("Data"), GUIColor(0.3f, 0.8f, 0.8f)]
        [HorizontalGroup("Data/1")]
        public AudioType audioType;

        [FoldoutGroup("Data"), GUIColor(0.3f, 0.8f, 0.8f)]
        [HorizontalGroup("Data/2")]
        [Range(0, 1)]
        public float volume = 1f;
    }
}