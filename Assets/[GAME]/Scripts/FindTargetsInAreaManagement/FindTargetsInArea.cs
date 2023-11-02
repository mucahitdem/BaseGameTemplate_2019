using System;
using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.FindTargetsInAreaManagement
{
    [RequireComponent(typeof(FindTargetInAreaVisualizer))]
    public class FindTargetsInArea : BaseComponent
    {
        private float CurrentRadius { get; set; }

        [SerializeField]
        private LayerMask layerMask;
        [SerializeField]
        private int maxTargetCount;
        [SerializeField]
        private float radius;
        [SerializeField]
        private Transform castPosition;

        
        private Collider[] _cols;
        private int _size;
        private FindTargetInAreaVisualizer _visualizer;

        
        protected virtual void OnValidate()
        {
            if (!_visualizer)
                _visualizer = GetComponent<FindTargetInAreaVisualizer>();

            _visualizer.LoadNewData(radius, castPosition);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            _cols = new Collider[maxTargetCount];
            CurrentRadius = radius;
        }


        public void SetNewRange(float newRad)
        {
            CurrentRadius = newRad;
        }
        public void Scan(Action<Collider> actionToDo)
        {
            _size = Physics.OverlapSphereNonAlloc(castPosition.position, CurrentRadius, _cols, layerMask);
            if (_size <= 0)
                return;

            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }

        public void Scan<T>(Func<Collider, T> actionToDo) where T : BaseComponent
        {
            _size = Physics.OverlapSphereNonAlloc(castPosition.position, CurrentRadius, _cols, layerMask);
            if (_size <= 0)
                return;

            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }
        public void UpdateRadius(float newRadius)
        {
            CurrentRadius = newRadius;
        }
    }
}