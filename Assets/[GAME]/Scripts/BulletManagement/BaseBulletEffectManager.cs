using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement
{
    public class BaseBulletEffectManager : BaseComponent
    {
        private BaseEffect _createdBulletParticleSystemEffect;
        private BaseEffect _createdHitParticleSystemEffect;

        private BaseEffect _createdMuzzleParticleSystemEffect;
        private BulletEffects _selectedBulletEffect;

        [SerializeField]
        private BulletEffects[] bulletEffects;

        public void CreateBulletEffect(Transform bulletCreateParent, FireType fireType)
        {
            _selectedBulletEffect = GetBulletEffect(fireType);

            if (_selectedBulletEffect.MuzzleParticleSystemEffect)
            {
                _createdMuzzleParticleSystemEffect =
                    _selectedBulletEffect.MuzzleParticleSystemEffect.BasePoolItem.PullObjFromPool<BaseEffect>(
                        bulletCreateParent.position, bulletCreateParent.eulerAngles);
                _createdMuzzleParticleSystemEffect.Play();
            }


            if (_selectedBulletEffect.BulletParticleSystemEffect)
            {
                _createdBulletParticleSystemEffect =
                    _selectedBulletEffect.BulletParticleSystemEffect.BasePoolItem.PullObjFromPool<BaseEffect>(
                        bulletCreateParent, Vector3.zero, Vector3.zero);
                _createdBulletParticleSystemEffect.Play();
            }
        }

        public void CreateHiEffect(Vector3 pos, Vector3 rot)
        {
            if (_selectedBulletEffect.HitParticleSystemEffect)
            {
                _createdHitParticleSystemEffect =
                    _selectedBulletEffect.HitParticleSystemEffect.BasePoolItem.PullObjFromPool<BaseEffect>(pos, rot);
                _createdHitParticleSystemEffect.Play();
            }
        }

        public void SendEffectsToThePool()
        {
            if (_createdBulletParticleSystemEffect)
                _createdBulletParticleSystemEffect.RePool();
        }


        private BulletEffects GetBulletEffect(FireType fireType)
        {
            for (var i = 0; i < bulletEffects.Length; i++) // use dictionary
            {
                var currentBulletEffects = bulletEffects[i];
                if (currentBulletEffects.FireType == fireType)
                    return currentBulletEffects;
            }

            return null;
        }
    }
}