using Scripts.CharacterManagement;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Game/Enemy/Enemy Data", order = 0)]
    public class BaseEnemyManagerDataSo : BaseCharacterDataSo
    {
        public BaseEnemyManagerData enemyManagerData;
    }
}