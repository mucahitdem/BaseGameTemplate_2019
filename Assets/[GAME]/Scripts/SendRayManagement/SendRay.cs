using System;
using UnityEngine;

namespace Scripts.GameScripts.SendRayManagement
{
    public class SendRay
    {
        private readonly SendRayData _sendRayData;
        private RaycastHit _hit;

        public SendRay(SendRayData sendRayData)
        {
            _sendRayData = sendRayData;
        }


        public void Scan(Action<Transform> toDo)
        {
            if (Physics.Raycast(_sendRayData.rayStartPoint.position, _sendRayData.rayStartPoint.forward, out _hit,
                _sendRayData.rayLength, _sendRayData.layerMask))
            {
                var currentTr = _hit.transform;
                toDo?.Invoke(currentTr);
            }
        }

        public Transform ScanAndGetTransform()
        {
            if (Physics.Raycast(_sendRayData.rayStartPoint.position, _sendRayData.rayStartPoint.forward, out _hit,
                _sendRayData.rayLength, _sendRayData.layerMask))
            {
                var currentTr = _hit.transform;
                return currentTr;
            }

            return null;
        }

        public Vector3 ScanAndGetPoint()
        {
            if (Physics.Raycast(_sendRayData.rayStartPoint.position, _sendRayData.rayStartPoint.forward, out _hit,
                _sendRayData.rayLength, _sendRayData.layerMask)) return _hit.point;

            return default;
        }
    }
}