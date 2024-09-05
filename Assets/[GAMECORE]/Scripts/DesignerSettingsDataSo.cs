using GAME.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "DesignerSettingsDataSo", menuName = "BaseGame/Data/DesignerSettingsDataSo", order = 0)]
    public class DesignerSettingsDataSo : SingletonScriptableObject<DesignerSettingsDataSo>
    {
        
        [Title("Item Deliver Related Variables")]
        public float itemJumpDuration;
        public float itemScale;
        
        [Title("Order Related Variables")]
        public float extraTimeAmountWhileBeingLate = 10f;
        public float orderDeliverDurationMultiplier = 1f;
        public float orderDistanceMultiplier = .01f;
        public float tipMinMultiplier;
        public float tipMaxMultiplier;
        public float payMinMultiplier;
        public float payMaxMultiplier;
        public float orderCreateDuration = 10f;
        
        [Title("Player Related Variables")]
        public float playerWalkSpeed = 10f;
    }
}