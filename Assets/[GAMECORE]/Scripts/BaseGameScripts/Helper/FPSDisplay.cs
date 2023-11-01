using TMPro;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class FpsDisplay : MonoBehaviour
    {
        private readonly float pollingTime = 1f;
        private int _frameCount;
        private float _time;

        [SerializeField]
        public TextMeshProUGUI fpsText;

        private void OnEnable()
        {
            if (fpsText == null)
                fpsText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _time += Time.deltaTime;
            _frameCount++;

            if (_time >= pollingTime)
            {
                var frameRate = Mathf.RoundToInt(_frameCount / _time);
                fpsText.text = frameRate + " fps";

                _time -= pollingTime;
                _frameCount = 0;
            }
        }
    }
}