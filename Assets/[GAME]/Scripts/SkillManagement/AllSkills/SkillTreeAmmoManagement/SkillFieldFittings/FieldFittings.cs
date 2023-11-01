using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillFieldFittings
{
    public class FieldFittings : BaseSkill
    {
        private FieldFittingsDataSo _fieldFittingsDataSo;

        private FieldFittingsDataSo FieldFittingsDataSo
        {
            get
            {
                if (!_fieldFittingsDataSo)
                    _fieldFittingsDataSo = (FieldFittingsDataSo) BaseSkillDataSo;

                return _fieldFittingsDataSo;
            }
        }

        public override void UseSkill()
        {
            // var data = FieldFittingsDataSo.fieldFittingsData;
            // var player = GameManager.Instance.Player;
            // player.Weapon.increaseReloadSpeedPercentage?.Invoke(data.reloadSpeedIncreasePercentage);
            // player.Weapon.increaseMaxBulletCount?.Invoke(data.ammoCountIncreaseAmount);
        }
    }
}