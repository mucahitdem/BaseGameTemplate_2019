using System;

namespace Scripts.GameScripts.CameraManagement
{
    [Serializable]
    public struct CameraShakeData
    {
        public float duration;
        public float amplitude;
        public float frequency;

        public CameraShakeData(float duration, float amplitude, float frequency)
        {
            this.duration = duration;
            this.amplitude = amplitude;
            this.frequency = frequency;
        }
    }
}