using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement
{
    public abstract class BaseAiMovement : BaseComponent
    {
        private float _initialSpeed;

        [SerializeField]
        private BaseAiMovementDataSo baseAiMovementDataSo;

        protected float CurrentSpeed;
        protected Transform CurrentTarget;
        protected Vector3 CurrentTargetPos;

        private bool isReachedTarget;
        public Action onGoingToTarget;
        public Action onReachedTarget;
        protected float ReachingDist;

        public Transform Target => CurrentTarget;

        protected bool CanMove { get; set; }

        protected virtual void Awake()
        {
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            CanMove = true;
            _initialSpeed = baseAiMovementDataSo.movementData.speed[0].value;
            ReachingDist = baseAiMovementDataSo.movementData.reachingDist;
            CurrentSpeed = _initialSpeed;
            DebugHelper.LogRed("AI SPEED: " + CurrentSpeed);
        }


        public void SetTarget(Transform newTarget)
        {
            CurrentTargetPos = default;
            CurrentTarget = newTarget;
        }

        public void SetTarget(Vector3 newTargetPos)
        {
            CurrentTarget = null;
            CurrentTargetPos = newTargetPos;
        }

        public virtual void SetSpeed(float newSpeed)
        {
            CurrentSpeed = newSpeed;
        }

        public virtual void ResetSpeed()
        {
            CurrentSpeed = _initialSpeed;
        }

        protected virtual void SetIfReachedTarget(bool isReached)
        {
            if (isReached)
            {
                if (!isReachedTarget)
                {
                    isReachedTarget = true;
                    onReachedTarget?.Invoke();
                    DebugHelper.LogRed("REACHED TARGET");
                }
            }
            else
            {
                if (isReachedTarget)
                {
                    isReachedTarget = false;
                    onGoingToTarget?.Invoke();
                }
            }
        }

        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
    }
}