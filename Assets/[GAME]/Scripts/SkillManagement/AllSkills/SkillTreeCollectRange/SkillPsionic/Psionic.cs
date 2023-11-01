using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.XpManagement;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillPsionic
{
    public class Psionic : BaseSkill
    {
        private PsionicData _psionicData;
        private PsionicDataSo _psionicDataSo;

        private PsionicDataSo PsionicDataSoDataSo
        {
            get
            {
                if (!_psionicDataSo)
                    _psionicDataSo = (PsionicDataSo) BaseSkillDataSo;

                return _psionicDataSo;
            }
        }

        public override void UseSkill()
        {
            _psionicData = PsionicDataSoDataSo.psionicData;

            XpCollectActionManager.increaseCollectRadiusPercentage?.Invoke(_psionicData.collectRangeIncreasePercentage);
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            XpCollectActionManager.onCollectedXp += OnCollectedXp;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            XpCollectActionManager.onCollectedXp -= OnCollectedXp;
        }

        private void OnCollectedXp(float xp)
        {
            if (ProbabilityCalculator.CheckProbability(_psionicData.onXpCollectedFillAmmoProbability))
                GameManager.Instance.Player.Weapon.fillAmmo?.Invoke(_psionicData.onXpCollectedFillAmmoCount);
        }
    }
}