using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.GameManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills._SkillBase
{
    public abstract class BaseSkill : BaseComponent
    {
        private SkillManager _skillManager;

        [SerializeField]
        private BaseSkillDataSo baseSkillDataSo;

        protected BaseSkillDataSo BaseSkillDataSo => baseSkillDataSo;

        public SkillManager SkillManager
        {
            get
            {
                if (!_skillManager)
                    _skillManager = GameManager.Instance.Player.SkillManager;
                return _skillManager;
            }
        }

        public abstract void UseSkill();
    }
}