using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.SendRayManagement
{
    public class SendRayVisualizer : BaseComponent
    {
        private SendRayData _sendRayData;

        [SerializeField]
        private Color gizmosColor = Color.red;

        public void LoadNewData(SendRayData sendRayData)
        {
            _sendRayData = sendRayData;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawRay(_sendRayData.rayStartPoint.position, _sendRayData.rayStartPoint.forward);
        }
    }
}