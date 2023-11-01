using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.EffectManagement._BaseClasses
{
    public abstract class BaseParticleSystemEffect : BaseEffect
    {
        [SerializeField]
        private ParticleSystem[] effects;

        public override void Play()
        {
            if (effects == null)
            {
                DebugHelper.LogYellow("THERE IS NO PARTICLES");
                return;
            }

            for (var i = 0; i < effects.Length; i++) effects[i].Play();
        }
    }
}