using Scripts.AnimatorManagement.Animators;
using Scripts.BaseGameScripts.Animator_Control;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.AnimatorManagement
{
    public class PlayerAnimator : DefaultAnimator
    {
        private AnimatorStateManager _animatorStateManager;


        private PlayerManager _playerManager;

        [SerializeField]
        private float inputMagnitudeToStartWalk;

        public float InputMagnitudeToStartWalk => inputMagnitudeToStartWalk;


        public override void Insert(BaseComponent baseComponent)
        {
            _playerManager = (PlayerManager) baseComponent;
            _animatorStateManager = ((DefaultAnimator)_playerManager.Animator).AnimatorStateManager;
        }


        public void UpdateAnimatorWithInput(bool inputExist)
        {
            if (inputExist)
            {
                if (!_animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    _animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
            }
            else
            {
                if (_animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    _animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, false);
            }
        }
    }
}