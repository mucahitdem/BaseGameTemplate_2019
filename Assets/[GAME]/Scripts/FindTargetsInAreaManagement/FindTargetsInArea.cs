using System;
using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    [RequireComponent(typeof(FindTargetInAreaVisualizer))]
    public class FindTargetsInArea : BaseComponent
    {
        private Collider[] _cols;
        private LayerMask _layerToScan;
        private int _size;


        private FindTargetInAreaVisualizer _visualizer;


        [SerializeField]
        private Transform castPosition;

        [SerializeField]
        private FindTargetsInAreaDataSo findTargetsInAreaDataSo;

        public float CurrentRadius { get; private set; }

        public float InitialRadius => FindTargetsInAreaDataSo.findTargetsInAreaData.radius;
        private FindTargetsInAreaDataSo FindTargetsInAreaDataSo => findTargetsInAreaDataSo;

        protected virtual void OnValidate()
        {
            if (!_visualizer)
                _visualizer = GetComponent<FindTargetInAreaVisualizer>();

            _visualizer.LoadNewData(FindTargetsInAreaDataSo.findTargetsInAreaData);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            var data = FindTargetsInAreaDataSo.findTargetsInAreaData;
            _layerToScan = data.layerMask;
            _cols = new Collider[data.maxTargetCount];
            CurrentRadius = data.radius;
        }


        public void SetNewRange(float newRad)
        {
            CurrentRadius = newRad;
        }

        public void Scan(Action<Collider> actionToDo)
        {
            _size = Physics.OverlapSphereNonAlloc(castPosition.position, CurrentRadius, _cols, _layerToScan);
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
            _size = Physics.OverlapSphereNonAlloc(castPosition.position, CurrentRadius, _cols, _layerToScan);
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
            //DebugHelper.LogYellow("NEW RADIUS UPDATED : " + newRadius);
            CurrentRadius = newRadius;
        }
    }
}