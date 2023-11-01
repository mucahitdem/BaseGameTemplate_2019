using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillFrigidDomain
{
    [CreateAssetMenu(fileName = "FrigidDomainDataSo", menuName = "Game/Skill/FrostDamage/FrigidDomainDataSo",
        order = 0)]
    public class FrigidDomainDataSo : BaseSkillDataSo
    {
        public FrigidDomainData frigidDomainData;
    }
}