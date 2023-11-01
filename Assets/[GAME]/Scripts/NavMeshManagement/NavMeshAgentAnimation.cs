using Scripts.AnimatorManagement.Animators;
using Scripts.GameScripts.AnimatorManagement.Animators;

namespace Scripts.GameScripts.NavMeshManagement
{
    public class NavMeshAgentAnimation : DefaultAnimator
    {
        public void UpdateAnimator(bool isStopping)
        {
            if (!isStopping)
            {
                if (!animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
            }
            else
            {
                if (animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, false);
            }
        }
    }
}