using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillPerspicacity;
using Scripts.GameScripts.XpManagement;

namespace Scripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillPerspicacity
{
    public class Perspicacity : BaseSkill
    {
        private PerspicacityDataSo _perspicacityDataSo;

        private PerspicacityDataSo PerspicacityDataSoDataSo
        {
            get
            {
                if (!_perspicacityDataSo)
                    _perspicacityDataSo = (PerspicacityDataSo) BaseSkillDataSo;

                return _perspicacityDataSo;
            }
        }

        public override void UseSkill()
        {
            // + %15 collectible toplama alanında genişleme gerçekleşir.
            //  Her deneyim puanı toplandığı zaman 1 saniyeliğine + %35 hareket hızı kazanılır.
            var data = PerspicacityDataSoDataSo.perspicacityData;

            XpCollectActionManager.increaseCollectRadiusPercentage?.Invoke(data.collectRangeIncreasePercentage);
            // MovementActionManager.increaseMovementSpeedPercentageInDuration?.Invoke(data.collectRangeIncreasePercentage,
            //     data.movementSpeedDurationGainedOnCollectedXp);
        }
    }
}