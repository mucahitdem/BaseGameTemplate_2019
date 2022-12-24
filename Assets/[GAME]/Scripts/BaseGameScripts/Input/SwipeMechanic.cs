using UnityEngine;

namespace Scripts.Input
{
    public class SwipeMechanic : BaseMechanic
    {
        private Transform _transformOfObj;

        private Transform TransformOfObj
        {
            get
            {
                if (!_transformOfObj)
                    _transformOfObj = transform;
                
                return _transformOfObj;
            }
            set => _transformOfObj = value;
        }
        
        [Header("Swipe Variables")]
        public float clampMaxVal;
        public float lerpMult = 1; 
        public float mouseDamp = 600; 

        [Header("Others")]
        private float _startPosX;
        private float _deltaMousePos;

        protected override void OnTapDown()
        {
            base.OnTapDown();
            ResetValues();
        }

        protected override void OnTapHold()
        {
            base.OnTapHold();
            UpdateDeltaMouse();
            Swipe();
        }

        protected override void OnTapHoldAndNotMove()
        {
            base.OnTapHoldAndNotMove();
        }

        protected override void OnTapUp()
        {
            base.OnTapUp();
        }


        private void UpdateDeltaMouse()
        {
            _deltaMousePos = UnityEngine.Input.mousePosition.x - _startPosX; // how much mouse dragged
        }


        private void Swipe()
        {
            Vector3 objPos = TransformOfObj.position;
                
            float xPos = objPos.x;
            xPos = Mathf.Lerp(xPos, xPos + (mouseDamp * (_deltaMousePos / Screen.width)), Time.deltaTime * lerpMult);
            xPos = Mathf.Clamp(xPos, -clampMaxVal, clampMaxVal);
            
            TransformOfObj.position = new Vector3(xPos, objPos.y, objPos.z);
            
            ResetValues();
        }
        
        
        private void Slide()
        {
            Vector3 objPos = TransformOfObj.position;
            
            float xPos = objPos.x;
            xPos = Mathf.Lerp(xPos, xPos + (mouseDamp * (_deltaMousePos / Screen.width)), Time.deltaTime * lerpMult);
            xPos = Mathf.Clamp(xPos, -clampMaxVal, clampMaxVal);

            TransformOfObj.position = new Vector3(xPos, objPos.y, objPos.z);

            ResetValues();
        }
        
        
        private void ResetValues()
        {
            _startPosX = UnityEngine.Input.mousePosition.x;
        }
    }
}