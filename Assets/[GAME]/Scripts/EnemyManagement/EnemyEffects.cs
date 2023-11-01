using System;
using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement
{
    [Serializable]
    public class EnemyEffects
    {
        [SerializeField]
        private BaseEffect dieParticleSystemEffect;

        [SerializeField]
        private BaseEffect flameParticleSystemEffect;

        [SerializeField]
        private BaseEffect icePrison;

        public BaseEffect DieParticleSystemEffect => dieParticleSystemEffect;
        public BaseEffect IcePrison => icePrison;
        public BaseEffect FlameParticleSystemEffect => flameParticleSystemEffect;
    }
}