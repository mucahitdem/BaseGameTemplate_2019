using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillBruiser
{
    public class Bruiser : BaseSkill
    {
        private BruiserDataSo _bruiserDataSo;

        private BruiserDataSo BruiserDataSo
        {
            get
            {
                if (!_bruiserDataSo)
                    _bruiserDataSo = (BruiserDataSo) BaseSkillDataSo;
                return _bruiserDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = BruiserDataSo.bruiserData;
            PlayerActionManager.gainMaxHp?.Invoke(data.healthIncreaseAmount);
            PlayerActionManager.increasePlayerSizePercentage?.Invoke(data.charSizeIncreasePercentage);
            MovementActionManager.increaseMovementSpeedPercentage?.Invoke(data.moveSpeedIncreasePercentage);
        }
    }
}