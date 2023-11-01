using Scripts.EnemyManagement;
using Scripts.GameManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillSoulStealClip
{
    public class SoulStealClip : BaseSkill
    {
        private SoulStealClipDataSo _soulStealClipDataSo;

        [SerializeField]
        private IncreaseReloadSpeed increaseReloadSpeed;

        private SoulStealClipDataSo SoulStealClipDataSo
        {
            get
            {
                if (!_soulStealClipDataSo)
                    _soulStealClipDataSo = (SoulStealClipDataSo) BaseSkillDataSo;

                return _soulStealClipDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = SoulStealClipDataSo.soulStealClipData;
            var playerManager = GameManager.Instance.Player;

            // increaseReloadSpeed.SetData(data.bulletReloadSpeedIncreasePercentageOnEnemyDied,
            //     ref EnemyActionManager.onEnemyDiedAtPosition,
            //     ref playerManager.Weapon.onReloadEnd);
        }
    }
}