using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillForbearance
{
    public class Forbearance : BaseSkill
    {
        private int _diedEnemyCount;
        private ForbearanceDataSo _forbearanceDataSo;

        private ForbearanceDataSo ForbearanceDataSo
        {
            get
            {
                if (!_forbearanceDataSo)
                    _forbearanceDataSo = (ForbearanceDataSo) BaseSkillDataSo;

                return _forbearanceDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = ForbearanceDataSo.forbearanceData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemyActionManager.onEnemyDiedAtPosition += OnEnemyDiedAtPosition;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemyActionManager.onEnemyDiedAtPosition -= OnEnemyDiedAtPosition;
        }

        private void OnEnemyDiedAtPosition(Vector3 pos, float damage, FireType fireType)
        {
            var data = ForbearanceDataSo.forbearanceData;
            if (fireType != data.fireType)
                return;

            _diedEnemyCount++;

            if (_diedEnemyCount >= data.enemyAmountToKill)
            {
                var player = GameManager.Instance.Player;

                player.Weapon.increaseBulletDamagePercentage?.Invoke(data.bulletDamageIncreasePercentage);
                _diedEnemyCount = 0;
            }
        }
    }
}