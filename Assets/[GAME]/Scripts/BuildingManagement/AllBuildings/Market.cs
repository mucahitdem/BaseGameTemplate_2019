using Scripts.BuildingManagement.UpgradableBuildingManagement;

namespace Scripts.BuildingManagement.AllBuildings
{
    public class Market : BaseUpgradableBuilding
    {
        public override void Upgrade()
        { 
            if (IsMaxed)
                return;
            base.Upgrade();
        }
    }
}