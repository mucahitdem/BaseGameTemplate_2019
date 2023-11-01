using Scripts.EnemyManagement;
using UnityEngine;

namespace Scripts.SkillHelpersManagement
{
    public class DealDamageEnemies : MonoBehaviour
    {
        public void DealDamage(BaseEnemyManager enemyManager, float percentage)
        {
            enemyManager.TakeDamageWithPercentageOfMaxHealth(percentage);
        }

        public void DealDamage(BaseEnemyManager[] enemies, float percentage)
        {
            for (var i = 0; i < enemies.Length; i++)
            {
                var currentEnemy = enemies[i];
                currentEnemy.TakeDamageWithPercentageOfMaxHealth(percentage);
            }
        }
    }
}