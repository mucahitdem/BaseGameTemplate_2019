using Cysharp.Threading.Tasks;
using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.EffectManagement._BaseClasses
{
    public abstract class ParticleSystemAutoRePoolEffect : BaseParticleSystemEffect
    {
        private int _convertedDelayedDuration;

        [SerializeField]
        private float durationToRePool;

        private void Awake()
        {
            _convertedDelayedDuration = (int) (durationToRePool * 1000);
        }


        public override void Play()
        {
            base.Play();
            RePoolEffect().GetAwaiter();
        }

        private async UniTask RePoolEffect()
        {
            await UniTask.Delay(_convertedDelayedDuration);
            RePool();
        }
    }
}