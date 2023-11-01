using Scripts.EnemyManagement;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts._AllDataSo
{
    [CreateAssetMenu(fileName = "AllEnemies", menuName = "Game/Data/AllEnemies", order = 0)]
    public class AllEnemiesDataSo : SingletonScriptableObject<AllEnemiesDataSo>
    {
        [SerializeField]
        private BaseEnemyManager[] allEnemies;

        static AllEnemiesDataSo()
        {
            SetNameOfDataSo(Defs.STATIC_SO_KEY_ALL_ENEMIES);
        }
    }
}