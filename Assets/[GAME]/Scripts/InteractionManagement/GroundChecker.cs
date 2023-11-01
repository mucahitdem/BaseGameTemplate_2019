using UnityEngine;

namespace Scripts.GameScripts.InteractionManagement
{
    public class GroundChecker : BaseInteractionManager
    {
        public bool IsGrounded { get; set; }

        private void Awake()
        {
            IsGrounded = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Defs.TAG_GROUND)) OnInteractedWithGround();
        }

        private void OnInteractedWithGround()
        {
            IsGrounded = true;
        }
    }
}