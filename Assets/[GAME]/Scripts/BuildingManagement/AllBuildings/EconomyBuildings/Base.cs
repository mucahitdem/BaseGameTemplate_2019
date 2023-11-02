namespace Scripts.BuildingManagement.AllBuildings.EconomyBuildings
{
    public class Base : BaseEconomyBuilding
    {
        public override void Upgrade()
        {
            if (IsMaxed)
                return;
            base.Upgrade();
        }

        protected override void OnMorningStarted(int morningCount)
        {
        }
    }
}