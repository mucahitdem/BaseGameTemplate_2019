using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeMovement.SkillWhiteWalker
{
    public class WhiteWalker : BaseSkill
    {
        private WhiteWalkerDataSo _whiteWalkerDataSo;

        [SerializeField]
        private StepCounter stepCounter;

        private WhiteWalkerDataSo WhiteWalkerDataSo
        {
            get
            {
                if (!_whiteWalkerDataSo)
                    _whiteWalkerDataSo = (WhiteWalkerDataSo) BaseSkillDataSo;

                return _whiteWalkerDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = WhiteWalkerDataSo.walkerData;
            MovementActionManager.increaseMovementSpeedPercentage?.Invoke(data.movementSpeedIncreasePercentage);
            stepCounter.SetData(data.walkAmountToGainHp,
                () => { PlayerActionManager.gainHp?.Invoke(data.hpAmountToGain); });
        }
    }
}