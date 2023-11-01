using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.TurretManagement
{
    [CreateAssetMenu(fileName = "TurretDataSo", menuName = "Game/Data/TurretDataSo", order = 0)]
    public class TurretDataSo : ScriptableObject
    {
        public int bulletDamage;
        public float bulletSpeedIncreaseAmount;


        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static TurretDataSo s_instance;

        public static TurretDataSo Instance => s_instance ??= Resources.Load<TurretDataSo>("TurretDataSo");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("TurretDataSo is missing in the resources folder.");
        }

        #endregion
    }
}