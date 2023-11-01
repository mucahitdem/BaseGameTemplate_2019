using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement.LightningManagement
{
    public class LightExplosion : BaseComponent
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        [SerializeField]
        private ParticleSystem[] lightExplosion;

        public BasePoolItem BasePoolItem => basePoolItem;

        public void PlayEffect()
        {
            for (var i = 0; i < lightExplosion.Length; i++)
            {
                var currentEffect = lightExplosion[i];
                currentEffect.Play();
            }
        }
    }
}