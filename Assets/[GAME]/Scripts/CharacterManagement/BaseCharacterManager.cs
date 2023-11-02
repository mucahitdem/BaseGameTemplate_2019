using System;
using Scripts.AnimatorManagement.Animators;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.RagDollManagement;
using Scripts.CharacterManagement;
using Scripts.GameScripts.AnimatorManagement.Animators;
using Scripts.GameScripts.StatsManagement;
using Scripts.StatsManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.CharacterManagement
{
    public abstract class BaseCharacterManager : BaseComponent
    {
        public Action<BaseCharacterManager> onDied;
        
        public bool IsEnabled { get; set; }
        public bool IsDead { get; protected set; }
        protected bool CanTakeDamage { get; set; }
        
        public virtual BaseAnimator Animator => animator;
        public BaseCharacterDataSo BaseCharacterDataSo => characterDataSo;
        protected BaseStatsManager StatsManager => baseStatsManager;
        
        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected DefaultAnimator animator;

        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected BaseStatsManager baseStatsManager;

        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        private BaseCharacterDataSo characterDataSo;
        
        [SerializeField]
        [FoldoutGroup("Base Char Variables")]
        protected RagDoll ragDoll;

        protected FireType fireType;

   

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