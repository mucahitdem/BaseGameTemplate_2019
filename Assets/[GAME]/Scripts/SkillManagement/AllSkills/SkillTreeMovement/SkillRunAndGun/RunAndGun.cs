using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeMovement.SkillRunAndGun;

namespace Scripts.SkillManagement.AllSkills.SkillTreeMovement.SkillRunAndGun
{
    public class RunAndGun : BaseSkill
    {
        private RunAndGunDataSo _runAndGunDataSo;

        private RunAndGunDataSo RunAndGunDataSo
        {
            get
            {
                if (!_runAndGunDataSo)
                    _runAndGunDataSo = (RunAndGunDataSo) BaseSkillDataSo;

                return _runAndGunDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = RunAndGunDataSo.runAndGunData;
            //MovementActionManager.increaseMovementSpeedPercentage?.Invoke(data.movementSpeedIncreasePercentage);
            //GameManager.Instance.Player.Weapon.increaseFireRatePercentage?.Invoke(data.fireRateIncreasePercentage);
        }
    }
}