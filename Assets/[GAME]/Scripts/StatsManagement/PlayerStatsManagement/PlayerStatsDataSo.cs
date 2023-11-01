using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "Game/Stats/Player Stats", order = 0)]
    [InlineEditor]
    public class PlayerStatsDataSo : BaseStatsDataSo
    {
        public PlayerStatsData playerStatsData;
    }
}