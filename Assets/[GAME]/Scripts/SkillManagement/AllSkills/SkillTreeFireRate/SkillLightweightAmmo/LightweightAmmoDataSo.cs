using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillLightweightAmmo
{
    [CreateAssetMenu(fileName = "LightweightAmmo", menuName = "Game/Skill/FireRate/LightweightAmmo", order = 0)]
    [InlineEditor]
    public class LightweightAmmoDataSo : BaseSkillDataSo
    {
        public LightweightAmmoData doubleBarrelData;
    }
}