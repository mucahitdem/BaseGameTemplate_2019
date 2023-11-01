using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.GameScripts.EffectManagement.AllEffects
{
    public class IcePrisonEffect : BaseEffect
    {
        [SerializeField]
        private GameObject gfx;

        public override void Play()
        {
            gfx.SetActive(true);
        }
    }
}