using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement.EnemyStatsManagement
{
    [CreateAssetMenu(fileName = "Enemy Stats", menuName = "Game/Stats/Enemy Stats", order = 0)]
    [InlineEditor]
    public class BaseEnemyStatsDataSo : BaseStatsDataSo
    {
        public BaseEnemyStatsData enemyStatsData;
    }
}