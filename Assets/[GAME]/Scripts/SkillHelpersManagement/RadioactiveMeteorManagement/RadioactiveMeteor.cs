using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement.RadioactiveMeteorManagement
{
    public class RadioactiveMeteor : BaseComponent
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        public BasePoolItem BasePoolItem => basePoolItem;

        public void Drop(Vector3 posToDrop, float damage, float continuousDamage)
        {
        }
    }
}