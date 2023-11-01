using System.Collections.Generic;
using Scripts.CharacterManagement;
using Scripts.FindTargetsInAreaManagement;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindNearestTargetInArea : FindTargetsInArea
    {
        private BaseCharacterManager _characterManager;
        private Vector3 _currentPosition;
        private float _distance;
        private float _nearestDistance;

        private Transform _nearestEnemy;

        // public int numberOfObjects = 3; // Number of nearest objects to find
        // public string targetTag; // Tag of the objects you want to consider for finding the nearest ones
        public Transform NearestTarget => null;


        public List<BaseCharacterManager> BaseCharacterManagers { get; } = new List<BaseCharacterManager>();

        // Call this function to find the nearest objects
        // public List<Transform> FindNearest()
        // {
        //     var nearestObjects = new List<Transform>();
        //     var objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        //
        //     // Calculate distances between the player (this object) and all objects with the target tag
        //     var objectDistances = new List<KeyValuePair<float, Transform>>();
        //     foreach (var obj in objectsWithTag)
        //     {
        //         var distance = Vector3.Distance(transform.position, obj.transform.position);
        //         objectDistances.Add(new KeyValuePair<float, Transform>(distance, obj.transform));
        //     }
        //
        //     // Sort the objects based on distance in ascending order
        //     objectDistances.Sort((a, b) => a.Key.CompareTo(b.Key));
        //
        //     // Take the first 'numberOfObjects' objects as the nearest ones
        //     for (var i = 0; i < numberOfObjects && i < objectDistances.Count; i++)
        //         nearestObjects.Add(objectDistances[i].Value);
        //
        //     return nearestObjects;
        // }
        public T FindNearestChar<T>() where T : Component
        {
            _nearestEnemy = null;
            _nearestDistance = Mathf.Infinity;
            _currentPosition = TransformOfObj.position;

            BaseCharacterManagers.Clear();
            Scan(GetEnemiesInRange);
            GetNearestEnemy();
            return _nearestEnemy ? _nearestEnemy.GetComponent<T>() : null;
        }


        private List<BaseCharacterManager> GetEnemiesInRange()
        {
            BaseCharacterManagers.Clear();
            Scan(GetEnemiesInRange);
            return BaseCharacterManagers;
        }

        private void GetNearestEnemy()
        {
            for (var i = 0; i < BaseCharacterManagers.Count; i++)
            {
                var currentChar = BaseCharacterManagers[i];
                if (currentChar.IsDead)
                    continue;

                _distance = Vector3.Distance(_currentPosition, currentChar.TransformOfObj.position);


                if (_distance < _nearestDistance)
                {
                    _nearestDistance = _distance;
                    _nearestEnemy = currentChar.TransformOfObj;
                }
            }
        }

        private void GetEnemiesInRange(Collider col)
        {
            if (col.TryGetComponent(out _characterManager))
                BaseCharacterManagers.Add(_characterManager);
        }
    }
}