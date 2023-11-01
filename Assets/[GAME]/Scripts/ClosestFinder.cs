using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class ClosestFinder : MonoBehaviour
    {
        public static T FindClosestTransform<T>(List<T> targets, Vector3 targetPoint) where T : MonoBehaviour
        {
            if (targets.Count == 0)
            {
                Debug.LogWarning("Points list is empty.");
                return null;
            }

            // Use LINQ to calculate the distance between targetPoint and each point in the list
            var closestTransform = targets
                .OrderBy(obj => Vector3.Distance(obj.transform.position, targetPoint))
                .First();

            return closestTransform;
        }

        public static List<T> FindNearestTransforms<T>(List<T> targets, Vector3 targetPoint, int count) where T : MonoBehaviour
        {
            if (targets.Count == 0)
            {
                Debug.LogWarning("Points list is empty.");
                return new List<T>();
            }

            // Use LINQ to calculate the distance between targetPoint and each point in the list
            var nearestTransforms = targets
                .OrderBy(obj => Vector3.Distance(obj.transform.position, targetPoint))
                .Take(count)
                .ToList();

            return nearestTransforms;
        }
    }
}