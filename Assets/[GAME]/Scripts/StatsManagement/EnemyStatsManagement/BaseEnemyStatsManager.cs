namespace Scripts.GameScripts.StatsManagement.EnemyStatsManagement
{
    public class BaseEnemyStatsManager : BaseStatsManager
    {
        public BaseEnemyStatsDataSo BaseEnemyStatsDataSo { get; private set; }

        protected void Awake()
        {
            BaseEnemyStatsDataSo = (BaseEnemyStatsDataSo) baseStatsDataSo;
        }
    }
}