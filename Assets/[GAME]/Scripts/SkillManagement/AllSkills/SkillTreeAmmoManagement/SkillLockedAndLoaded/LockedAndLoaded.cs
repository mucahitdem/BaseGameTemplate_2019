using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillLockedAndLoaded
{
    public class LockedAndLoaded : BaseSkill
    {
        private LockedAndLoadedDataSo _lockedAndLoadedDataSo;

        [SerializeField]
        private IncreaseBulletDamage increaseBulletDamage;

        private LockedAndLoadedDataSo LockedAndLoadedDataSo
        {
            get
            {
                if (!_lockedAndLoadedDataSo)
                    _lockedAndLoadedDataSo = (LockedAndLoadedDataSo) BaseSkillDataSo;

                return _lockedAndLoadedDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = LockedAndLoadedDataSo.lockedAndLoadedData;

            var playerManager = GameManager.Instance.Player;

            playerManager.Weapon.increaseReloadSpeedPercentage?.Invoke(data.reloadSpeedIncreasePercentage);

            increaseBulletDamage.SetData(data.bulletDamageIncreaseDurationOnReloadEnd,
                data.bulletDamageIncreasePercentageOnReloadEnd,
                ref playerManager.Weapon.onReloadEnd);
        }
    }
}