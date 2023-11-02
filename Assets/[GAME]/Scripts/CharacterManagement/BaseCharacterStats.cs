using System;

namespace Scripts.CharacterManagement
{
    [Serializable]
    public class BaseCharacterStats
    {
        public int health;
        public float moveSpeed;
        public int attackDamage;
        public float attackSpeed;
        public float attackRange;
    }
}