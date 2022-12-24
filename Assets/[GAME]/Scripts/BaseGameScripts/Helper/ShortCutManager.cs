using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Scripts
{
    public class ShortCutManager : MonoBehaviour
    {
        public List<ShortCutData> keycodes = new List<ShortCutData>();
        private ShortCutData _shortCutData;
        
        private void Update()
        {
            for (int i = 0; i < keycodes.Count; i++)
            {
                _shortCutData = keycodes[i];
                if (UnityEngine.Input.GetKeyDown(_shortCutData.keyCode))
                {
                    _shortCutData.unityEvent?.Invoke();
                }
            }
        }
    }

    [Serializable]
    public class ShortCutData
    {
        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public KeyCode keyCode;
        
        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public UnityEvent unityEvent;
    }
}