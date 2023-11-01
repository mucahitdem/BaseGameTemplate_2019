using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.BulletManagement.AllBullets.BaseBulletManagement;

namespace Scripts.GameScripts.BulletManagement
{
    public class BulletManager : SingletonMono<BulletManager>
    {
        private readonly List<BaseBullet> _bullets = new List<BaseBullet>();

        protected override void OnAwake()
        {
        }

        private void Update()
        {
            if (_bullets.Count <= 0)
                return;

            for (var i = 0; i < _bullets.Count; i++)
            {
                var currentBullet = _bullets[i];
                currentBullet.OnUpdate();
            }
        }

        public void AddBullet(BaseBullet bulletToAdd)
        {
            if (!_bullets.Contains(bulletToAdd))
                _bullets.Add(bulletToAdd);
        }

        public void RemoveBullet(BaseBullet bulletToRemove)
        {
            if (_bullets.Contains(bulletToRemove))
                _bullets.Remove(bulletToRemove);
        }
    }
}