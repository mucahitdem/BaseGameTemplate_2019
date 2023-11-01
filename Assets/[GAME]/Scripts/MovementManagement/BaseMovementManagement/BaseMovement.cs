using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.MovementManagement.BaseMovementManagement;
using Scripts.GameScripts.MovementManagement.SpeedAcceleratorManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.MovementManagement.BaseMovementManagement
{
    public class BaseMovement : BaseComponent
    {
        private float _currentMoveSpeed;
        private float _initialSpeed;
        private BaseMovementData _movementData;

        private Vector3 _playerInput;

        private PlayerManager _playerManager;

        [SerializeField]
        private BaseMovementDataSo baseMovementDataSo;

        [SerializeField]
        private Joystick joystick;

        [SerializeField]
        private MovementSpeedAccelerator speedAccelerator;

        public Vector3 PlayerInput => _playerInput;

        public override void Insert(BaseComponent baseComponent)
        {
            _playerManager = (PlayerManager) baseComponent;
        }

        private void Awake()
        {
            speedAccelerator.Insert(this);
            _movementData = baseMovementDataSo.baseMovementData;
            _initialSpeed = _movementData.moveSpeed[0].value;
            _currentMoveSpeed = _initialSpeed;
            DebugHelper.LogGreen("PLAYER SPEED: " + _currentMoveSpeed);
        }


        public void OnUpdate()
        {
            GetInput();
            Look();
        }

        public void OnFixedUpdate()
        {
            Move();
            AddDownForce();
        }


        public void UpgradeSpeed(int index)
        {
            _initialSpeed = _movementData.moveSpeed[index].value;
            _currentMoveSpeed = _initialSpeed;
        }

        public void AddRemoveSpeed(float amountToAdd)
        {
            _currentMoveSpeed += amountToAdd;
        }

        public CostAndValue UpgradeSpeedValues(int index)
        {
            if (index >= _movementData.moveSpeed.Length)
                return new CostAndValue(-1, -1);
            return _movementData.moveSpeed[index];
        }

        public void IncreaseSpeed(float percentage)
        {
            _initialSpeed += MathCalculations.CalculatePercentage(_initialSpeed, percentage);
            var newSpeed = _currentMoveSpeed + MathCalculations.CalculatePercentage(_currentMoveSpeed, percentage);
            //DebugHelper.LogYellow("MOVE SPEED : " + _currentMoveSpeed + " /// " + _initialSpeed);
            _currentMoveSpeed = newSpeed;
        }

        public void IncreaseSpeedTemporary(float percentage)
        {
            var newSpeed = _currentMoveSpeed + MathCalculations.CalculatePercentage(_currentMoveSpeed, percentage);
            //DebugHelper.LogYellow("TEMPORARY MOVE SPEED : " + _currentMoveSpeed + " /// " + newSpeed);
            _currentMoveSpeed = newSpeed;
        }

        public void ResetSpeed()
        {
            //DebugHelper.LogYellow("MOVE SPEED : " + _currentMoveSpeed + " /// " + _initialSpeed);
            _currentMoveSpeed = _initialSpeed;
        }


        private void AddDownForce()
        {
            Rb.angularVelocity = Vector3.zero;
        }

        private void GetInput()
        {
            if (!joystick)
                return;
            var horInput = joystick.Horizontal;
            var verInput = joystick.Vertical;
            _playerInput = new Vector3(horInput, 0f, verInput);
        }

        private void Look()
        {
            if (_playerInput != default) TransformOfObj.LookAt(TransformOfObj.position + _playerInput, Vector3.up);
        }

        private void Move()
        {
            if (_playerInput.magnitude < .1f)
                return;


            var targetPos = TransformOfObj.position + TransformOfObj.forward * (_currentMoveSpeed * Time.deltaTime);
            Rb.MovePosition(targetPos);
        }
    }
}