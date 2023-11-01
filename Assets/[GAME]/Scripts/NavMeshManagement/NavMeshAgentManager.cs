using System;
using Scripts.BaseGameScripts.Animator_Control;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.NavMeshManagement;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.NavMeshManagement
{
    [RequireComponent(typeof(NavMeshAgentAnimation))]
    public sealed class NavMeshAgentManager : BaseComponent
    {
        private float _distance;
        private Transform _target;
        private Vector3 _targetPos;


        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private NavMeshAgentAnimation anim;

        [SerializeField]
        private AnimatorStateManager animatorStateManager;

        [SerializeField]
        private float moveSpeed;

        public Action onReachedTarget;

        [SerializeField]
        private float reachingDist = 1f;

        [SerializeField]
        private float rotSpeed;


        protected override void OnEnable()
        {
            base.OnEnable();
            agent.speed = moveSpeed;
        }


        public void MoveAndUpdateAnimator()
        {
            MoveToTarget();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            agent.isStopped = false;
        }

        public void SetTarget(Vector3 targetPos)
        {
            _targetPos = targetPos;
            agent.isStopped = false;
        }


        private void ResetTargetVariables()
        {
            agent.isStopped = true;
            _target = null;
            _targetPos = default;
        }

        private void MoveToTarget()
        {
            if (!agent.enabled)
                return;


            if (!_target && _targetPos == default)
            {
                _target = GameManager.Instance.Player.TransformOfObj;
                return;
            }


            if (_target)
            {
                LookAt();
                agent.SetDestination(_target.position);
            }
            else if (_targetPos != default)
            {
                LookAt();
                agent.SetDestination(_targetPos);
            }

            CheckIfReachedTarget();
        }

        private void LookAt()
        {
            var targetPos = _target ? _target.position : _targetPos;
            var rotation = Quaternion.LookRotation(targetPos - TransformOfObj.position);
            TransformOfObj.rotation = Quaternion.Slerp(TransformOfObj.rotation, rotation, Time.deltaTime * rotSpeed);
        }

        private void CheckIfReachedTarget()
        {
            if (IsReachedTarget())
                onReachedTarget?.Invoke();
        }

        private bool IsReachedTarget()
        {
            return Dist() <= reachingDist;
        }

        private float Dist()
        {
            if (_target)
                _distance = Vector3.Distance(_target.position, TransformOfObj.position);
            else if (_targetPos != default)
                _distance = Vector3.Distance(_targetPos, TransformOfObj.position);

            return _distance;
        }
    }
}