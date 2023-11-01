using Scripts.BuildingManagement.BaseBuildingManagement;
using UnityEngine;

namespace Scripts.BuildingManagement.UpgradableBuildingManagement
{
    [CreateAssetMenu(fileName = "BaseUpgradableBuildingDataSo", menuName = "Game/Building/BaseUpgradableBuildingDataSo", order = 0)]
    public class BaseUpgradableBuildingDataSo : BaseBuildingDataSo
    {
        public BaseUpgradableBuildingData upgradableBuildingData;
    }
}