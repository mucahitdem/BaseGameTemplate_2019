using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.InputManagement
{
    public class PlayerInputManager : BaseComponent
    {
        [SerializeField]
        [ReadOnly]
        private Joystick joystick;
        
        private Vector3 _playerInput;

        private void Awake()
        {
            joystick = GetComponent<Joystick>();
        }
        
        
        public Vector3 GetInput()
        {
            var horInput = joystick.Horizontal;
            var verInput = joystick.Vertical;
            _playerInput = new Vector3(horInput, 0f, verInput);
            return _playerInput;
        }
    }
}