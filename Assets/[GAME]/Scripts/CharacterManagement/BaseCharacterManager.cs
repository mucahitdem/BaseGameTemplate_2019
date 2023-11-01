using System;
using Scripts.AnimatorManagement.Animators;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.RagDollManagement;
using Scripts.GameScripts.AnimatorManagement.Animators;
using Scripts.GameScripts.StatsManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.CharacterManagement
{
    public abstract class BaseCharacterManager : BaseComponent
    {
        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected DefaultAnimator animator;

        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected BaseStatsManager baseStatsManager;

        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        private BaseCharacterDataSo characterDataSo;

        protected int damageLevelIndex;

        protected FireType fireType;

        protected int healthLevelIndex;
        protected int movementLevelIndex;
        public Action<BaseCharacterManager> onDied;

        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected RagDoll ragDoll;

        public Action UpgradeDamage;
        public Action UpgradeHealth;
        public Action UpgradeMovementSpeed;

        public virtual BaseAnimator Animator => animator;
        public BaseCharacterDataSo BaseCharacterDataSo => characterDataSo;
        protected BaseStatsManager StatsManager => baseStatsManager;

        public bool IsEnabled { get; set; }
        public bool IsDead { get; protected set; }
        protected bool CanTakeDamage { get; set; }
        protected bool IsPushedBack { get; set; }

        protected virtual void Awake()
        {
            IsEnabled = true; // if we have sth like TAP TO START -- need to disable this
            CanTakeDamage = true;
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            baseStatsManager.onDied += OnDied;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            baseStatsManager.onDied -= OnDied;
        }

        public virtual void Reset()
        {
            IsEnabled = true;
            IsDead = false;
            CanTakeDamage = true;
        }

        public void Push(Vector3 dir)
        {
            Rb.AddForce(dir, ForceMode.Impulse);
        }

        public void TakeDamage(int damage, FireType newFireType)
        {
            fireType = newFireType;
            TakeDamage(damage);
        }

        public void TakeDamageWithPercentageOfMaxHealth(float percentage)
        {
            baseStatsManager.TakeDamagePercentageOfMaxHealth(percentage);
        }

        protected virtual void TakeDamage(float damage)
        {
            if (!CanTakeDamage)
                return;

            baseStatsManager.TakeDamage(damage);
        }

        public virtual void ControlActivate(bool isActivated) // connect to an event
        {
            IsEnabled = isActivated;
        }

        protected virtual void OnDied(float damageTaken)
        {
            CanTakeDamage = false;
            IsDead = true;
            IsEnabled = false;
            onDied?.Invoke(this);
            // if (ragDoll) 
            //     ragDoll.HeadShot(10);
        }
    }
}