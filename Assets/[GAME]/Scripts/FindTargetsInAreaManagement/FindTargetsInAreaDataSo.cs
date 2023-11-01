using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    [CreateAssetMenu(fileName = "Find Target In Area Data So",
        menuName = "Game/Find Target/Find Target In Area Data So", order = 0)]
    [InlineEditor]
    public class FindTargetsInAreaDataSo : BaseScriptableObject
    {
        public FindTargetsInAreaData findTargetsInAreaData;
    }
}