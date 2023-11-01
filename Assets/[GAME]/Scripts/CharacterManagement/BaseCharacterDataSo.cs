using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.CharacterManagement
{
    [CreateAssetMenu(fileName = "BaseCharacterDataSo", menuName = "Game/Character/BaseCharacterDataSo", order = 0)]
    [InlineEditor]
    public class BaseCharacterDataSo : BaseScriptableObject
    {
        public BaseCharacterData baseCharacterData;
    }
}