using System.Collections.Generic;
using System.Linq;
using GAME.Scripts;
using UnityEngine;

namespace Scripts.Helpers
{
    public class ClosestFinder : MonoBehaviour
    {
        public static T FindClosestType<T>(List<T> targets, Vector3 targetPoint) where T : MonoBehaviour
        {
            var closestTransform = targets
                .OrderBy(obj => Vector3.Distance(obj.transform.position, targetPoint))
                .First();
        
            return closestTransform;
        }
        
        public static T FindClosestTransform<T>(List<T> targets, Vector3 targetPoint) where T : MonoBehaviour
        {
            var closestTransform = targets
                .OrderBy(obj => Vector3.Distance(obj.transform.position, targetPoint))
                .First();

            return closestTransform;
        }

        public static void SortByDist<T>(ref List<T> targets, Vector3 targetPoint) where T : Transform
        {
            targets = targets
                .OrderBy(obj => Vector3.Distance(obj.position, targetPoint))
                .ToList();
        }

        public static void TargetsInRangeSortedByDist<T>(ref List<T> sortedList, Vector3 point, float maxRange)
            where T : MonoBehaviour
        {
            float sqrMaxRange = maxRange * maxRange;

            for (int i = sortedList.Count - 1; i >= 0; i--)
            {
                T target = sortedList[i];
                float sqrDistance = (target.transform.position - point).sqrMagnitude;

                if (sqrDistance > sqrMaxRange)
                {
                    sortedList.RemoveAt(i);
                }
            }

            sortedList.Sort((a, b) => (a.transform.position - point).sqrMagnitude.CompareTo((b.transform.position - point).sqrMagnitude));
        }
    }
}