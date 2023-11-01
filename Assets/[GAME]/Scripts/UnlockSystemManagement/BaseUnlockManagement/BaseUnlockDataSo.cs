using Scripts.GameScripts.DevHelperTools.SoCreator;
using UnityEngine;

namespace Scripts.GameScripts.UnlockSystemManagement.BaseUnlockManagement
{
    [CreateAssetMenu(fileName = "BaseUnlockData", menuName = "Game/Unlock/BaseUnlockData", order = 0)]
    public class BaseUnlockDataSo : BaseScriptableObject
    {
        public BaseUnlockData baseUnlockData;
    }
}