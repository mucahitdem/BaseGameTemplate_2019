using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillFrigidDomain
{
    public class FrigidDomain : BaseSkill
    {
        private FrigidDomainDataSo _frigidDomainDataSo;

        private FrigidDomainDataSo FrigidDomainDataSo
        {
            get
            {
                if (!_frigidDomainDataSo)
                    _frigidDomainDataSo = (FrigidDomainDataSo) BaseSkillDataSo;

                return _frigidDomainDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = FrigidDomainDataSo.frigidDomainData;
        }
    }
}