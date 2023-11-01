using UnityEngine;

namespace Scripts.GameScripts.EffectManagement._BaseClasses
{
    public abstract class BaseAnimatedEffect : BaseEffect
    {
        [SerializeField]
        private string animName;

        public override void Play()
        {
            AnimOfObj.Play(animName, -1, 0f);
        }
    }
}