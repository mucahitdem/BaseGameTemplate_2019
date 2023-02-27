using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlRotateWithSwipe : BaseControl
    {
        private CalculateDeltaMouse _calculateDeltaMouse;
        
        [Header("Swipe Variables")]
        public float clampMaxVal;

        public float lerpMultiplier = 1;
        public float mouseDamp = 600;

        private float _screenWidth;


        private void Awake()
        {
            _screenWidth = Screen.width;
            _calculateDeltaMouse = new CalculateDeltaMouse();
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
            var objRot = TransformOfObj.eulerAngles;

            var yRot = objRot.y;
            yRot = Mathf.Lerp(yRot, yRot + mouseDamp * (_calculateDeltaMouse.deltaMousePos.x / _screenWidth), Time.deltaTime * lerpMultiplier);
            //yRot = Mathf.Clamp(yRot, -clampMaxVal, clampMaxVal);

            TransformOfObj.eulerAngles = new Vector3(objRot.x, yRot, objRot.z);

            _calculateDeltaMouse.ResetValues();
        }
    }
}