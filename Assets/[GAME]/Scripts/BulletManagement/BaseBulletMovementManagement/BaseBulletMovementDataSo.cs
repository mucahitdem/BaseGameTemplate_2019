using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.BaseBulletMovementManagement
{
    [CreateAssetMenu(fileName = "BaseBulletMovementDataSo", menuName = "Game/Bullet/BaseBulletMovementDataSo",
        order = 0)]
    public class BaseBulletMovementDataSo : ScriptableObject
    {
        public BaseBulletMovementData bulletMovementData;
    }
}