using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.CameraManagement
{
    public class VisualBlockDetector : BaseComponent
    {
        private Color _color;
        private RaycastHit _hit;
        private PlayerManager _player;
        private MaterialPropertyBlock _propertyBlock;
        private Renderer _rend;

        private void Start()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _player = GameManager.Instance.Player;
        }

        private void Update()
        {
            ControlVisual();
        }

        private void ControlVisual()
        {
            if (Physics.Raycast(TransformOfObj.position, TransformOfObj.forward, out _hit))
            {
                if (_hit.transform != _player.TransformOfObj)
                {
                    _rend = _hit.transform.GetComponent<Renderer>();
                    _rend.GetPropertyBlock(_propertyBlock);
                    _color = _propertyBlock.GetColor("_Color");
                    _color.a = 0f;
                    _propertyBlock.SetColor("_Color", _color);
                    _rend.SetPropertyBlock(_propertyBlock);
                }
                else
                {
                    if (!_rend)
                        return;

                    _rend.GetPropertyBlock(_propertyBlock);
                    _color = _propertyBlock.GetColor("_Color");
                    _color.a = 1f;
                    _propertyBlock.SetColor("_Color", _color);
                    _rend.SetPropertyBlock(_propertyBlock);
                }
            }
        }
    }
}