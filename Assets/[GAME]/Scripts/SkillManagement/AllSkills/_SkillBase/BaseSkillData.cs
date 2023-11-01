using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills._SkillBase
{
    [Serializable]
    public class BaseSkillData
    {
        [TextArea(10, 20)]
        public string skillDescription = "DESCRIPTION";

        [PreviewField(50, ObjectFieldAlignment.Left)]
        public Sprite skillIcon;

        public string skillName;
    }
}