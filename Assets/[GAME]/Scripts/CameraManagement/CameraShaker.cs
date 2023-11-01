using Cinemachine;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts.CameraManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.CameraManagement
{
    public class CameraShaker : BaseComponent
    {
        private CinemachineBasicMultiChannelPerlin _perlin;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private CinemachineVirtualCamera vcam;

        private void Awake()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
            _perlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            CameraActionManager.shakeCamera += ShakeCamera;
            timer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            CameraActionManager.shakeCamera -= ShakeCamera;
            timer.onTimerEnded -= OnTimerEnded;
        }


        private void OnTimerEnded()
        {
            _perlin.m_AmplitudeGain = 0f;
        }

        [Button]
        private void ShakeCamera(CameraShakeData shakeData)
        {
            timer.UpdateTimerValue(shakeData.duration);
            timer.RestartTimer();
            _perlin.m_FrequencyGain = shakeData.frequency;
            _perlin.m_AmplitudeGain = shakeData.amplitude;
        }
    }
}