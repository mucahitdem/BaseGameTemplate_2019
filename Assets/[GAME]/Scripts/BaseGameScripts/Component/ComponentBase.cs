using UnityEngine;

namespace Scripts.Component
{
    public class ComponentBase : EventSubscriber
    {
        private Transform _transformOfObj;
        public Transform TransformOfObj
        {
            get
            {
                if (!_transformOfObj)
                    _transformOfObj = transform;
                return _transformOfObj;
            }
            set => _transformOfObj = value;
        }

        private GameObject _go;
        public GameObject Go
        {
            get
            {
                if (!_go)
                    _go = gameObject;
                return _go;
            }
            set => _go = value;
        }

        private Rigidbody _rb;
        public Rigidbody Rb
        {
            get
            {
                if (!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
            set => _rb = value;
        }
        
        private Collider _col;
        public Collider Col
        {
            get
            {
                if (!_col)
                    _col = GetComponent<Collider>();
                return _col;
            }
            set => _col = value;
        }

        private RectTransform _rect;
        public RectTransform Rect
        {
            get
            {
                if (!_rect)
                    _rect = GetComponent<RectTransform>();
                return _rect;
            }
            set => _rect = value;
        }

        public override void SubscribeEvent()
        {
            
        }

        public override void UnsubscribeEvent()
        {
            
        }
    }
}