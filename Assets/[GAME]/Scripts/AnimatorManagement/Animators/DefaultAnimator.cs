using Scripts.BaseGameScripts.Animator_Control;
using Scripts.GameScripts.AnimatorManagement.Animators;
using UnityEngine;

namespace Scripts.AnimatorManagement.Animators
{
    public class DefaultAnimator : BaseAnimator
    {
        [SerializeField]
        protected AnimatorStateManager animatorStateManager;

        public AnimatorStateManager AnimatorStateManager => animatorStateManager;

        public override void SetAnimSpeed(float newSpeed)
        {
            base.SetAnimSpeed(newSpeed);
            animatorStateManager.AnimOfObj.speed = newSpeed;
        }
    }
}