using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.XpManagement;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillGaussField
{
    public class GaussField : BaseSkill
    {
        private GaussFieldDataSo _gaussFieldDataSo;

        private GaussFieldDataSo GaussFieldDataSoDataSo
        {
            get
            {
                if (!_gaussFieldDataSo)
                    _gaussFieldDataSo = (GaussFieldDataSo) BaseSkillDataSo;

                return _gaussFieldDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = GaussFieldDataSoDataSo.gaussFieldData;
            XpCollectActionManager.increaseCollectRadiusPercentage?.Invoke(data.collectRangeIncreasePercentage);
        }
    }
}