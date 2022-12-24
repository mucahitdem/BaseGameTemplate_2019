using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Helper
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField]
        List<float> timeScales = new List<float>();

        private int _index;

        public void ChangeTimeScale()
        {
            IncreaseIndex();
            Time.timeScale = timeScales[_index];
        }

        private void IncreaseIndex()
        {
            _index++;
            if (_index >= timeScales.Count)
            {
                _index = 0;
            }
        }
    }
}