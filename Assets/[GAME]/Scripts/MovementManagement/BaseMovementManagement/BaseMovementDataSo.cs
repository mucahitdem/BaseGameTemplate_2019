using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.MovementManagement.BaseMovementManagement
{
    [CreateAssetMenu(fileName = "Base Movement", menuName = "Game/Movement/Base Movement", order = 0)]
    [InlineEditor]
    public class BaseMovementDataSo : BaseScriptableObject
    {
        public BaseMovementData baseMovementData;
    }
}