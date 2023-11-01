using DG.Tweening;
using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement;
using Scripts.GameScripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.StatsManagement.EnemyStatsManagement;
using UnityEngine;

namespace Scripts.EnemyManagement
{
    public abstract class BaseEnemyManager : BaseCharacterManager
    {
        private EventQueue _eventQueue;

        private bool _isFrost;
        private int _pushCount;
        private Collider[] _tempCol;
        private WaitForSeconds _waitForSeconds;

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

        public BasePoolItem BasePoolItem => basePoolItem;
        public BaseEnemyStatsManager EnemyStatsManager { get; private set; }

        private BaseAiMovement BaseAiMovement => baseAiMovement;

        private EventQueue EventQueue
        {
            get
            {
                if (_eventQueue == null)
                {
                    var eventQueue = GameManager.Instance.EventQueue;
                    _eventQueue = eventQueue ? eventQueue : FindObjectOfType<EventQueue>();
                }

                return _eventQueue;
            }
            set => _eventQueue = value;
        }

        protected override void Awake()
        {
            base.Awake();
            EnemyStatsManager = (BaseEnemyStatsManager) baseStatsManager;
            BasePoolItem.onSendToPool += OnGetFromPool;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            IsEnabled = true;
            CanTakeDamage = true;
            IsDead = false;
            DOVirtual.DelayedCall(.1f, () => { EnemyStatsManager.ResetHealth(); });
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
            //UiActionManager.createFloatingUi?.Invoke(createPos, damage.ToString(CultureInfo.InvariantCulture));
            _pushCount++;
            if (!IsPushedBack && baseAiMovement.Target && _pushCount % 2 == 1)
                //IsPushedBack = true;
                TransformOfObj.DOMove(-TransformOfObj.forward * .5f, .5f).SetRelative(true);
            //Rb.AddForce(-TransformOfObj.forward * 3000f);
        }

        protected override void OnDied(float takenDamage)
        {
            base.OnDied(takenDamage);

            if (enemyEffectManager)
                enemyEffectManager.CreateDieEffect();

            if (EventQueue)
                EventQueue.Add(() =>
                {
                    var position = TransformOfObj.position;
                    EnemyActionManager.onEnemyDiedWithHp?.Invoke(position,
                        EnemyStatsManager.BaseEnemyStatsDataSo.enemyStatsData.xpValue);
                    EnemyActionManager.onEnemyDiedAtPosition?.Invoke(position, takenDamage, fireType);
                    EnemyActionManager.onEnemyDied?.Invoke(this);
                }, "CART");

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