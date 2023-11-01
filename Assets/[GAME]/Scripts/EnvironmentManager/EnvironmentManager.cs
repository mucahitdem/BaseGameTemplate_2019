using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.EnemySpawnManagement;

namespace Scripts.GameScripts.EnvironmentManager
{
    public class EnvironmentManager : BaseComponent
    {
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnvironmentActionManager.getCols += GetCols;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnvironmentActionManager.getCols -= GetCols;
        }

        private BuildingCollider[] GetCols()
        {
            var cols = FindObjectsOfType<BuildingCollider>();
            return cols;
        }
    }
}