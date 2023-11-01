using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillLockedAndLoaded
{
    [CreateAssetMenu(fileName = "LockedAndLoaded", menuName = "Game/Skill/AmmoManagement/LockedAndLoaded", order = 0)]
    public class LockedAndLoadedDataSo : BaseSkillDataSo
    {
        public LockedAndLoadedData lockedAndLoadedData;
    }
}