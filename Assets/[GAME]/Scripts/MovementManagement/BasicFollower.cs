using System;
using Scripts.MovementManagement.AiMovementManagement.BaseAiMovementManagement;
using UnityEngine;

namespace Scripts.EnemyManagement.AiMovementManagement.MovementTypes
{
    public class BasicFollower : BaseAiMovement
    {
        [SerializeField]
        private float turnSpeed = 15f;

        
        public override void OnUpdate()
        {
            if (CanMove)
            {
                if (!IsReachedToTarget())
                {
                    LookAt();
                    SetIfReachedTarget(false);
                }
                else
                {
                    SetIfReachedTarget(true);
                }
            }
        }
        public override void OnFixedUpdate()
        {
            if (CanMove)
            {
                if (!IsReachedToTarget())
                    Move();
                else
                    Rb.velocity = Vector3.zero;
            }
        }
        public override void SetSpeed(float newSpeed)
        {
            base.SetSpeed(newSpeed);
            if (Math.Abs(newSpeed) < .0001f)
                Rb.isKinematic = true;
        }
        public override void ResetSpeed()
        {
            base.ResetSpeed();
            if (Math.Abs(currentSpeed) > .0f)
                Rb.isKinematic = false;
        }


        private void LookAt()
        {
            if (currentTarget)
            {
                var targetPos = currentTarget.position;
                targetPos.y = 0f;
                LookAtTarget(targetPos, TransformOfObj);
            }
            else if (currentTargetPos != default)
            {
                var targetPos = currentTargetPos;
                targetPos.y = 0f;
                LookAtTarget(targetPos, TransformOfObj);
            }
        }
        private void LookAtTarget(Vector3 targetPos, Transform objToTurn)
        {
            var dir = targetPos - objToTurn.position;
            var lookRotation = Quaternion.LookRotation(dir);
            var rotation = Quaternion.Lerp(objToTurn.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            objToTurn.rotation = Quaternion.Euler(new Vector3(0f, rotation.y, 0f));
        }
        private void Move()
        {
            if (!currentTarget && currentTargetPos == default)
            {
                Rb.velocity = Vector3.zero;
                return;
            }

            Rb.MovePosition(TransformOfObj.position + TransformOfObj.forward * (currentSpeed * Time.deltaTime));

            //Rb.velocity = TransformOfObj.forward * (Time.deltaTime * CurrentSpeed);
        }
        private bool IsReachedToTarget()
        {
            return Dist(currentTarget ? currentTarget.position : currentTargetPos) <= ReachingDist;
        }
        private float Dist(Vector3 pos)
        {
            return Vector3.Distance(TransformOfObj.position, pos);
        }
    }
}