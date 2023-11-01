using Scripts.WeaponManagement.WeaponLevelAndRankManagement.RankManagement;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement.WeaponLevelAndRankManagement.RankManagement
{
    [CreateAssetMenu(fileName = "Weapon Level Data", menuName = "Game/Weapon/Weapon Level/Weapon Level Data",
        order = 0)]
    public class WeaponRankDataSo : ScriptableObject
    {
        public WeaponRankData weaponRankData;
    }
}