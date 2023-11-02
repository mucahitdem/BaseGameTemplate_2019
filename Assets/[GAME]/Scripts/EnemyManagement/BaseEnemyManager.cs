using DG.Tweening;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.Pool;
using Scripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement;
using UnityEngine;

namespace Scripts.EnemyManagement
{
    public abstract class BaseEnemyManager : BaseCharacterManager
    {
        public BasePoolItem BasePoolItem => basePoolItem;
        private BaseAiMovement BaseAiMovement => baseAiMovement;
        

        [SerializeField]
        private BaseAiMovement baseAiMovement;

        [SerializeField]
        private BasePoolItem basePoolItem;

        [SerializeField]
        private EnemyEffectManager enemyEffectManager;

        [SerializeField]
        private FindTargetsInArea findTargetsInArea;

        [SerializeField]
        private Transform gfx;

        private bool _isFrost;
        private int _pushCount;
        private Collider[] _tempCol;
        private WaitForSeconds _waitForSeconds;

        protected override void Awake()
        {
            base.Awake();
            BasePoolItem.onSendToPool += OnGetFromPool;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            IsEnabled = true;
            CanTakeDamage = true;
            IsDead = false;
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            baseAiMovement.onReachedTarget += OnReachedTarget;
            baseAiMovement.onGoingToTarget += OnGoingToTarget;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            baseAiMovement.onReachedTarget -= OnReachedTarget;
            baseAiMovement.onGoingToTarget -= OnGoingToTarget;
        }

        private void Update()
        {
            if (IsDead || _isFrost)
                return;
            baseAiMovement.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (IsDead)
                return;
            baseAiMovement.OnFixedUpdate();
        }

        public void SetTarget(Transform target)
        {
            if (target)
                DebugHelper.LogRed("TARGET SET : " + target.name);
            baseAiMovement.SetTarget(target);
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
        }

        public void SetTarget(Vector3 targetPos)
        {
            baseAiMovement.SetTarget(targetPos);
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
        }


        private void OnFrost()
        {
            if (_isFrost)
                return;
            _isFrost = true;

            baseAiMovement.SetSpeed(0f);
            animator.SetAnimSpeed(0f);
            if (enemyEffectManager)
                enemyEffectManager.CreateIcePrisonEffect();
        }

        private void NonFrost() // Buzdolabı : şaka :)
        {
            if (enemyEffectManager)
                enemyEffectManager.SendIcePrisonEffectToPool();
            animator.ResetSpeed();
            baseAiMovement.ResetSpeed();
            _isFrost = false;
        }

        protected override void TakeDamage(float damage)
        {
            if (!CanTakeDamage)
                return;
            EnemyActionManager.onEnemyGotDamage?.Invoke(this);
            base.TakeDamage(damage);
            var createPos = TransformOfObj.position + new Vector3(0, 2, 0);
            _pushCount++;
        }

        protected override void OnDied(float takenDamage)
        {
            base.OnDied(takenDamage);

            if (enemyEffectManager)
                enemyEffectManager.CreateDieEffect();

            
            var position = TransformOfObj.position;
            EnemyActionManager.onEnemyDiedAtPosition?.Invoke(position, takenDamage, fireType);
            EnemyActionManager.onEnemyDied?.Invoke(this);

            baseAiMovement.SetTarget(null);
        }

        private void OnReachedTarget()
        {
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_WALK, false);
        }

        private void OnGoingToTarget()
        {
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
        }

        private void OnGetFromPool()
        {
            if (enemyEffectManager)
                enemyEffectManager.SendIcePrisonEffectToPool();
            animator.ResetSpeed();
            baseAiMovement.ResetSpeed();
            _isFrost = false;
            IsDead = false;
            StatsManager.ResetHealth();
        }
    }
}