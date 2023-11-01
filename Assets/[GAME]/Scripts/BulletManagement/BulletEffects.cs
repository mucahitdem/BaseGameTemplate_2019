using System;
using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement
{
    [Serializable]
    public class BulletEffects
    {
        [SerializeField]
        private BaseEffect bulletParticleSystemEffect;


        [SerializeField]
        private FireType fireType;

        [SerializeField]
        private BaseEffect hitParticleSystemEffect;

        [SerializeField]
        private BaseEffect muzzleParticleSystemEffect;

        public FireType FireType => fireType;
        public BaseEffect MuzzleParticleSystemEffect => muzzleParticleSystemEffect;
        public BaseEffect BulletParticleSystemEffect => bulletParticleSystemEffect;
        public BaseEffect HitParticleSystemEffect => hitParticleSystemEffect;
    }
}