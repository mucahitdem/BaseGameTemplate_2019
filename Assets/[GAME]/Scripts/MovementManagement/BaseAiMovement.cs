using System;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.MovementManagement.AiMovementManagement.BaseAiMovementManagement
{
    public abstract class BaseAiMovement : BaseMovement
    {
        public Action onGoingToTarget;
        public Action onReachedTarget;
        
        public Transform Target => currentTarget;
        protected bool CanMove { get; set; }

        protected float currentSpeed;
        protected Transform currentTarget;
        protected Vector3 currentTargetPos;

        private bool isReachedTarget;
        private float _initialSpeed;
        protected float ReachingDist { get; private set; }

      
        
        protected override void OnEnable()
        {
            base.OnEnable();
            CanMove = true;
            currentSpeed = _initialSpeed;
            DebugHelper.LogRed("AI SPEED: " + currentSpeed);
        }


        public void SetTarget(Transform newTarget)
        {
            currentTargetPos = default;
            currentTarget = newTarget;
        }

        public void SetTarget(Vector3 newTargetPos)
        {
            currentTarget = null;
            currentTargetPos = newTargetPos;
        }

        public virtual void SetSpeed(float newSpeed)
        {
            currentSpeed = newSpeed;
        }

        public virtual void ResetSpeed()
        {
            currentSpeed = _initialSpeed;
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