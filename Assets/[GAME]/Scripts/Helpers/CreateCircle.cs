using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class CreateCircle : BaseComponent
    {
        private PlayerManager _playerManager;

        [SerializeField]
        private float heightOffset;

        [SerializeField]
        private LineRenderer lineRenderer;

        [SerializeField]
        private int numSegments = 32;

        [SerializeField]
        public float radius = 1f;

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;

                return _playerManager;
            }
        }

        private void Update()
        {
            if (!PlayerManager)
                return;

            DrawCircle();
        }


        [Button]
        private void DrawCircle()
        {
            lineRenderer.positionCount = numSegments + 1;
            lineRenderer.loop = true;

            for (var i = 0; i <= numSegments; i++)
            {
                var angle = 2f * Mathf.PI * i / numSegments;
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var position = new Vector3(x, heightOffset, z) + PlayerManager.TransformOfObj.position;
                lineRenderer.SetPosition(i, position);
            }
        }
    }
}