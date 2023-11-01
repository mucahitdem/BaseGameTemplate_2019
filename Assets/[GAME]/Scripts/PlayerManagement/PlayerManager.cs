using _GAME_.Scripts.GameScripts.SoundManagement;
using Scripts.AttackManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.CharacterManagement;
using Scripts.EnemyManagement;
using Scripts.GameScripts.AnimationEventsManagement;
using Scripts.GameScripts.CameraManagement;
using Scripts.GameScripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.RigUpdaterManagement;
using Scripts.GfxManagement;
using Scripts.InputManagement;
using Scripts.MovementManagement;
using Scripts.SkillManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.PlayerManagement
{
    public sealed class PlayerManager : BaseCharacterManager
    {
        public SkillManager SkillManager => skillManager;
        public FindNearestTargetInArea FindNearestTargetInArea => findNearestTargetInArea;
        public BaseRigUpdater BaseRigUpdater => baseRigUpdater;
        private BaseMovementWithInput BaseMovementWithInput => baseMovementWithInput;
        

        [SerializeField]
        private PlayerInputManager playerInputManager;

        [SerializeField]
        private BaseMovementWithInput baseMovementWithInput;

        [SerializeField]
        private BaseRigUpdater baseRigUpdater;

        [SerializeField]
        private FindNearestTargetInArea findNearestTargetInArea;

        [SerializeField]
        private CharacterGfxManager characterGfxManager;
        
        [SerializeField]
        private SkillManager skillManager;

        [SerializeField]
        private BaseAttackManager attackManager;
        
        [SerializeField]
        private AnimationEvents animationEvents;
        
        [ReadOnly]
        public bool isRiding;
        
        private Vector3 input;

        
        protected override void Awake()
        {
            base.Awake();
            baseMovementWithInput.Insert(this);
            animator.Insert(this);
            baseRigUpdater.Insert(this);
        }
        private void Update()
        {
            if (!IsEnabled)
            {
                if (IsDead)
                {
                    if (animator.AnimatorStateManager.GetBool(Defs.ANIM_KEY_DIE) == false)
                        animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, true, true);
                }
                
                return;
            }

            input = playerInputManager.GetInput();

            if (Time.frameCount % 10 == 0)// to do cancel
            {
                var targetToShoot = FindNearestTargetInArea.FindNearestChar<BaseEnemyManager>();
            }

            baseMovementWithInput.OnUpdate();


            if (isRiding)
                DebugHelper.LogRed("IS RIDING");
            else
               UpdateAnimator();
        }
        private void FixedUpdate()
        {
            if (!IsEnabled || IsDead)
                return;
            baseMovementWithInput.OnFixedUpdate();
        }
        private void LateUpdate()
        {
            // if (!IsEnabled || IsDead)
            //     return;
            // var target = GetNearestEnemy()?.TransformOfObj;
            // baseRigUpdater.UpdateRig(target);
        }
        
        
        

  
        public override void Reset()
        {
            base.Reset();
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, false, true);
            Rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            characterGfxManager.Gfx.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
        }
        
        
        
        
        protected override void OnDied(float takenDamage)
        {
            if (IsDead)
                return;

            SoundManager.Instance.PlayGlobalAudio(Defs.AUDIO_PLAYER_DEATH);
            base.OnDied(takenDamage);
            Rb.constraints = RigidbodyConstraints.FreezeAll;
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, true, true);
        }
        protected override void TakeDamage(float damage)
        {
            if (IsDead || !IsEnabled || !CanTakeDamage)
                return;
            base.TakeDamage(damage);
            animator.AnimatorStateManager.SetTrigger(Defs.ANIM_KEY_HIT, true);
            CameraActionManager.shakeCamera?.Invoke(new CameraShakeData(.09f, 6f, .1f));
        }

        


        private void UpdateAnimator()
        {
            var animStateManager = animator.AnimatorStateManager;
            if (IsInputExist())
            {
                if (!animStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
            }
            else
            {
                if (animStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animStateManager.SetBool(Defs.ANIM_KEY_WALK, false);
            }
        }
        private BaseEnemyManager GetNearestEnemy()
        {
            var targetToShoot = FindNearestTargetInArea.FindNearestChar<BaseEnemyManager>();
            return targetToShoot;
        }
        private bool IsInputExist()
        {
            return Mathf.Abs(input.magnitude) > 0f;
        }
    }
}