using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement
{
    [CreateAssetMenu(fileName = "BaseAiMovementDataSo", menuName = "Game/Enemy/BaseAiMovementDataSo", order = 0)]
    [InlineEditor]
    public class BaseAiMovementDataSo : BaseScriptableObject
    {
        public BaseAiMovementData movementData;
    }
}