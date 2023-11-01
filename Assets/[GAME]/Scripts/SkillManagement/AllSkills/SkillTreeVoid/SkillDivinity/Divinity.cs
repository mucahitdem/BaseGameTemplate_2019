using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillDivinity
{
    public class Divinity : BaseSkill
    {
        private int _diedEnemyCount;
        private DivinityDataSo _divinityDataSo;
        private int _repeatCount;

        private DivinityDataSo DivinityDataSo
        {
            get
            {
                if (!_divinityDataSo)
                    _divinityDataSo = (DivinityDataSo) BaseSkillDataSo;

                return _divinityDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = DivinityDataSo.divinityData;
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
            _diedEnemyCount++;
            if (_diedEnemyCount >= DivinityDataSo.divinityData.gainHealthAfterKilledEnemyAmount)
            {
                //PlayerActionManager.gainHp?.Invoke(1);
                _diedEnemyCount = 0;
                _repeatCount++;
                if (_repeatCount >= DivinityDataSo.divinityData.maxRepeatAmount)
                    EnemyActionManager.onEnemyDiedAtPosition -= OnEnemyDiedAtPosition;
            }
        }
    }
}