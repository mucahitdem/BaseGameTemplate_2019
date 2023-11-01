using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.Helpers;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.BaseBulletMovementManagement
{
    public abstract class BaseBulletMovement : BaseComponent
    {
        private float _initialSpeed;

        [SerializeField]
        private BaseBulletMovementDataSo baseAiMovementDataSo;

        protected float currentSpeed;

        public bool CanMove { get; set; }

        protected virtual void Awake()
        {
            CanMove = true;
            _initialSpeed = baseAiMovementDataSo.bulletMovementData.Speed;
            currentSpeed = _initialSpeed;
        }

        public virtual void MoveToDir(Vector3 dir)
        {
        }

        public void UpdateSpeed(float speedIncreasePercentage)
        {
            if (Math.Abs(speedIncreasePercentage) < .0001f)
            {
                currentSpeed = _initialSpeed;
                return;
            }

            currentSpeed += MathCalculations.CalculatePercentage(currentSpeed, speedIncreasePercentage);
        }

        public virtual void SetSpeed(float newSpeed)
        {
            currentSpeed = newSpeed;
        }

        public virtual void ResetSpeed()
        {
            currentSpeed = _initialSpeed;
        }

        public virtual void UpdateRotation(Vector3 dir)
        {
        }
    }
}