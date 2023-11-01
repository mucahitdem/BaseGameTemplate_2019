using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillRapidReload
{
    public class RapidReload : BaseSkill
    {
        private RapidReloadDataSo _rapidReloadDataSo;

        private RapidReloadDataSo RapidReloadDataSo
        {
            get
            {
                if (!_rapidReloadDataSo)
                    _rapidReloadDataSo = (RapidReloadDataSo) BaseSkillDataSo;

                return _rapidReloadDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = RapidReloadDataSo.rapidReloadData;
            var player = GameManager.Instance.Player;
            player.Weapon.increaseReloadSpeedPercentage?.Invoke(data.reloadSpeedIncreasePercentage);
            player.Weapon.increaseFireRatePercentage?.Invoke(data.fireRateIncreasePercentage);
        }
    }
}