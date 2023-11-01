using Scripts.GameScripts.AnimatorManagement.Animators;

namespace Scripts.AnimatorManagement.Animators
{
    public class MeshAnimatedChar : BaseAnimator
    {
        // [SerializeField]
        // private MeshAnimatorBase meshAnimator;

        public override void SetAnimSpeed(float newSpeed)
        {
            // base.SetAnimSpeed(newSpeed);
            // if (Math.Abs(newSpeed) < .001f)
            // {
            //     meshAnimator.Pause();
            // }
            // else
            // {
            //     meshAnimator.speed = newSpeed;
            //     meshAnimator.Play();
            // }
            //
            // DebugHelper.LogRed("NEW ANIM SPEED : " + newSpeed);
        }

        public override void ResetSpeed()
        {
            // base.ResetSpeed();
            // if (Math.Abs(CurrentAnimSpeed) < .001f)
            // {
            //     meshAnimator.Pause();
            // }
            // else
            // {
            //     meshAnimator.speed = CurrentAnimSpeed;
            //     meshAnimator.Play();
            // }
        }
    }
}