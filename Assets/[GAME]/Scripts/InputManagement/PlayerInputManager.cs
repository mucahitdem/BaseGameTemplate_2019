using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.InputManagement
{
    public class PlayerInputManager : BaseComponent
    {
        //private PlayerControls _playerControls;
        private Vector2 _input;

        [SerializeField]
        private float inputAcceleration;

        public float Horizontal => _input.x;
        public float Vertical => _input.y;

        private void Awake()
        {
            //_playerControls = new PlayerControls();
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            // _playerControls.Player.Enable();
            // _playerControls.Player.Movement.performed += MovementOnStarted;
            // _playerControls.Player.Movement.canceled += MovementOnCanceled;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            // _playerControls.Player.Disable();
            // _playerControls.Player.Movement.performed -= MovementOnStarted;
            // _playerControls.Player.Movement.canceled -= MovementOnCanceled;
        }

        // private void MovementOnCanceled(InputAction.CallbackContext obj)
        // {
        //     // var instantInput = obj.ReadValue<Vector2>();
        //     // if (Math.Abs(instantInput.x) < .0001f)
        //     //     _input.x = 0f;
        //     // if (Math.Abs(instantInput.y) < .0001f)
        //     //     _input.y = 0f;
        //
        // }

        // private void MovementOnStarted(InputAction.CallbackContext obj)
        // {
        //     DebugHelper.LogRed("INPUT : " + _input);
        //     
        //     var instantInput = obj.ReadValue<Vector2>();
        //     if (instantInput.x > 0)
        //     {
        //         _input.x += inputAcceleration * Time.deltaTime;
        //         
        //     }
        //     else if (instantInput.x < 0)
        //     {
        //         _input.x -= inputAcceleration * Time.deltaTime;
        //     }
        //     else
        //         _input.x = 0f;
        //     
        //     
        //     if (instantInput.y > 0)
        //     {
        //         _input.y += inputAcceleration * Time.deltaTime;
        //     }
        //     else if (instantInput.y < 0)
        //     {
        //         _input.y -= inputAcceleration * Time.deltaTime;
        //     }
        //     else
        //         _input.y = 0f;
        //
        //     _input.x = Mathf.Clamp(_input.x, -1f, 1f);
        //     _input.y = Mathf.Clamp(_input.y, -1f, 1f);
        // }
    }
}