using System;
using Scripts.CharacterManagement;
using Scripts.GameScripts.InteractionManagement;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement
{
    public class BulletInteractionManager : BaseInteractionManager
    {
        private BaseCharacterManager _baseEnemy;
        public Action<BaseCharacterManager> onInteract;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _baseEnemy))
            {
                onInteract?.Invoke(_baseEnemy);
                ResetVariable();
                // Damage();
                // SendToPool();
            }
            else
            {
                onInteract?.Invoke(null);
                ResetVariable();
                // SendToPool();
            }
        }

        private void ResetVariable()
        {
            _baseEnemy = null;
        }
    }
}