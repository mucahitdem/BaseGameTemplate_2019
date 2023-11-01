using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.CameraManagement
{
    public class ControlViewBannerObjects : BaseComponent
    {
        private float _dist;
        private RaycastHit _hit;
        private MakeMeshTransparent _makeMeshTransparent;

        [SerializeField]
        private LayerMask layer;

        private void Update()
        {
            if (Physics.Raycast(TransformOfObj.position, TransformOfObj.forward, out _hit, 1000f, layer))
            {
                if (_hit.transform.TryGetComponent(out _makeMeshTransparent))
                    _makeMeshTransparent.ControlTransparent(.2f);
            }
            else
            {
                ResetValues();
            }
        }

        private void ResetValues()
        {
            if (_makeMeshTransparent)
            {
                _makeMeshTransparent.ControlTransparent(1);
                _makeMeshTransparent = null;
            }
        }
    }
}