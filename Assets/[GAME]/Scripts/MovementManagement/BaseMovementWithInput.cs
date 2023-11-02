using UnityEngine;

namespace Scripts.MovementManagement
{
    public class BaseMovementWithInput : BaseMovement
    {
        [SerializeField]
        [Range(0,1)]
        private float minInputValueToMove = .1f;
        
        private float _currentMoveSpeed;
        private Vector3 input;


        public void SetInput(Vector3 newInput)
        {
            input = newInput;
        }
        public void OnUpdate()
        {
            Look();
        }
        public void OnFixedUpdate()
        {
            Move();
            AddDownForce();
        }
        
        private void AddDownForce()
        {
            Rb.angularVelocity = Vector3.zero;
        }


        private void Look()
        {
            if (input != default)
                TransformOfObj.LookAt(TransformOfObj.position + input, Vector3.up);
        }

        private void Move()
        {
            if (input.magnitude < minInputValueToMove)
                return;

            var targetPos = TransformOfObj.position + TransformOfObj.forward * (_currentMoveSpeed * Time.deltaTime);
            Rb.MovePosition(targetPos);
        }
    }
}