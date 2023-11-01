using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEditor;
using UnityEngine;

namespace Scripts.GameScripts.DefendAreaManagement
{
    public class InteractionChecker : BaseComponent
    {
        [SerializeField]
        private RadiusAndColor area;

        public Action onEnteredArea;
        public Action onExitArea;

        private PlayerManager tempPlayer;

        private void OnValidate()
        {
            area.sphereCollider.radius = area.radius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out tempPlayer)) //hard coded -> fix 
                onEnteredArea?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out tempPlayer) && !IsInsideCircle(tempPlayer.TransformOfObj.position)
            ) // todo hard coded -> fix 
                onExitArea?.Invoke();
        }

        private bool IsInsideCircle(Vector3 position)
        {
            var distance = Vector3.Distance(position, TransformOfObj.position);
            return distance < area.radius;
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Handles.color = area.gizmoColor;
            Handles.DrawWireDisc(TransformOfObj.position, TransformOfObj.up, area.radius);
#endif
            //ExtensionMethods.DrawDisc(TransformOfObj.position, area.radius, area.gizmoColor);
        }
    }
}