using Scripts.GameScripts;
using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts._NewData
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character/CharacterData", order = 0)]
    [InlineEditor]
    public class CharacterData : ScriptableObject
    {
        public CostAndValue[] damageAndCost;
        public BaseScriptableObject[] data;
    }
}