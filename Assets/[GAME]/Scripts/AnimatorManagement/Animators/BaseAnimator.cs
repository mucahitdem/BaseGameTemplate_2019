using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.AnimatorManagement.Animators
{
    public class BaseAnimator : BaseComponent
    {
        protected float CurrentAnimSpeed;

        [SerializeField]
        private float defaultAnimSpeed;

        private void Awake()
        {
            CurrentAnimSpeed = defaultAnimSpeed;
            SetAnimSpeed(CurrentAnimSpeed);
        }

        public virtual void SetAnimSpeed(float newSpeed)
        {
            CurrentAnimSpeed = newSpeed;
        }

        public virtual void ResetSpeed()
        {
            CurrentAnimSpeed = defaultAnimSpeed;
        }
    }
}