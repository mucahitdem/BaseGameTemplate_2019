using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillRegeneration
{
    public class Regeneration : BaseSkill
    {
        private RegenerationDataSo _regenerationDataSo;

        [SerializeField]
        private Timer timer;

        private RegenerationDataSo RegenerationDataSo
        {
            get
            {
                if (!_regenerationDataSo)
                    _regenerationDataSo = (RegenerationDataSo) BaseSkillDataSo;
                return _regenerationDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = RegenerationDataSo.regenerationData;
            timer.UpdateTimerValue(data.hpGainDuration);
            timer.onTimerEnded += OnTimerEnded;
            timer.RestartTimer();
        }

        private void OnTimerEnded()
        {
            //PlayerActionManager.gainHp?.Invoke(RegenerationDataSo.regenerationData.hpGainAmount);
        }
    }
}