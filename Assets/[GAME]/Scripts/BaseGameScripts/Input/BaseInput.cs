using UnityEngine;

namespace Scripts.Input
{
    public abstract class BaseInput : MonoBehaviour
    {
        private bool _isTouchScreen;
        
        public virtual void Start()
        {
           TouchSettings();
        }

        private void Update()
        {
            GetInput();
        }

        private void TouchSettings()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _isTouchScreen = true;
                UnityEngine.Input.multiTouchEnabled = false;
            }
            else
            {
                _isTouchScreen = false;
            }
        }
        
        private void GetInput()
        {
            if (_isTouchScreen)
                TouchControl();
            else
                MouseControl();
        }

        private void MouseControl()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                OnTapDown();
            }
            else if (UnityEngine.Input.GetMouseButton(0))
            {
                OnTapHold();
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                OnTapUp();
            }
        }

        private void TouchControl()
        {
            switch (UnityEngine.Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    OnTapDown();
                    break;

                case TouchPhase.Moved:
                    OnTapHold();
                    break;
                
                case TouchPhase.Stationary:
                    OnTapHoldAndNotMove();
                    break;
                
                case TouchPhase.Ended:
                    OnTapUp();
                    break;
            }
        }

        protected abstract void OnTapDown();

        protected abstract void OnTapHold();

        protected abstract void OnTapHoldAndNotMove();

        protected abstract void OnTapUp();
    }
}