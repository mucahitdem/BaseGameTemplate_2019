using Scripts.BaseGameScripts.ComponentManagement;
using UnityEditor;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindTargetInAreaVisualizer : BaseComponent
    {
        [SerializeField]
        private FindTargetsInAreaData _findTargetsInAreaData;

        [SerializeField]
        private bool disableVisual;

        [SerializeField]
        private Color gizmosColor = Color.red;

        public void LoadNewData(FindTargetsInAreaData findTargetsInAreaData)
        {
            _findTargetsInAreaData = findTargetsInAreaData;
        }

        private void OnDrawGizmos()
        {
            if (_findTargetsInAreaData == null || disableVisual)
                return;
            // Gizmos.color = gizmosColor;
            // Gizmos.DrawWireSphere(TransformOfObj.position, _findTargetsInAreaData.radius);
#if UNITY_EDITOR
            Handles.color = gizmosColor;
            Handles.DrawWireDisc(TransformOfObj.position, Vector3.up, _findTargetsInAreaData.radius);

#endif
        }
    }
}