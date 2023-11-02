using Scripts.BaseGameScripts.Control;
using UnityEngine;

namespace Scripts.InputManagement
{
    public class Joystick : BaseControl
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        [SerializeField] private float sensitivity;
        [SerializeField] private float deadZone;

        private CalculateDeltaMouse _calculateDeltaMouse;

        private void Awake()
        {
            _calculateDeltaMouse = new CalculateDeltaMouse();
        }


        protected override void OnTapUp()
        {
            base.OnTapUp();
            Horizontal = 0f;
            Vertical = 0f;
            _calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapDown()
        {
            base.OnTapDown();
            _calculateDeltaMouse.ResetValues();
        }
        protected override void OnTapHold()
        {
            base.OnTapHold();
            GetInput();
        }

        
        
        public override void GetInput()
        {
            _calculateDeltaMouse.CalculateDeltaMousePos();
            Swipe();
        }
        
        
        
        private void Swipe()
        {
            var input = _calculateDeltaMouse.deltaMousePos;

            Horizontal = 0f;
            Vertical = 0f;
            
            if (Mathf.Abs(input.x) > deadZone)
            {
                Horizontal = input.x * sensitivity;
                Horizontal = Mathf.Clamp(Horizontal, -1f, 1f);
            }

            if (Mathf.Abs(input.y) > deadZone)
            {
                Vertical = input.y * sensitivity;
                Vertical = Mathf.Clamp(Vertical, -1f, 1f);
            }
        }
    }
}