using System;
using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement
{
    public class StepCounter : BaseComponent
    {
        private float _desiredDistance;
        private Vector3 _lastPosition;

        private float _totalDistance;
        public Action onCompletedTarget;

        protected override void OnEnable()
        {
            base.OnEnable();
            _lastPosition = transform.position;
        }

        private void Update()
        {
            var position = TransformOfObj.position;
            var distanceMoved = Vector3.Distance(position, _lastPosition);
            _totalDistance += distanceMoved;
            _lastPosition = position;

            if (_totalDistance >= _desiredDistance)
            {
                Debug.Log("Total Distance: " + _totalDistance);
                _totalDistance = 0f;
                onCompletedTarget?.Invoke();
            }
        }

        public void SetData(float targetDistance, Action onReachedTarget)
        {
            _desiredDistance = targetDistance;
            onCompletedTarget += () =>
            {
                Debug.Log("PLAYER GAINED HP : " + _totalDistance);
                onReachedTarget?.Invoke();
            };
        }
    }
}