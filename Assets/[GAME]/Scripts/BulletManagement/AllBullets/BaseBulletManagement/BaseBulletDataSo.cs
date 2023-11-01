using Scripts.GameScripts.DevHelperTools.SoCreator;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.AllBullets.BaseBulletManagement
{
    [CreateAssetMenu(fileName = "BaseBulletDataSo", menuName = "Game/Bullet/BaseBulletDataSo", order = 0)]
    public class BaseBulletDataSo : BaseScriptableObject
    {
        public BaseBulletData baseBulletData;
    }
}