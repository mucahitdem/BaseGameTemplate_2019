using Scripts.GameScripts.EffectManagement._BaseClasses;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement
{
    public class EnemyEffectManager : MonoBehaviour
    {
        private BaseEffect _createdDieParticleSystemEffect;
        private BaseEffect _createdFireParticleSystemEffect;

        private BaseEffect _createdIcePrison;

        [SerializeField]
        private EnemyEffects enemyEffects;

        public void CreateIcePrisonEffect()
        {
            _createdIcePrison =
                enemyEffects.IcePrison.BasePoolItem.PullObjFromPool<BaseEffect>(transform, Vector3.zero,
                    Vector3.right * -90f);
            _createdIcePrison.Play();
        }

        public void CreateDieEffect()
        {
            _createdDieParticleSystemEffect =
                enemyEffects.DieParticleSystemEffect.BasePoolItem.PullObjFromPool<BaseEffect>(
                    transform.position + Vector3.up);
            _createdDieParticleSystemEffect.Play();
        }

        public void CreateFireEffect()
        {
            _createdFireParticleSystemEffect =
                enemyEffects.FlameParticleSystemEffect.BasePoolItem.PullObjFromPool<BaseEffect>(transform, Vector3.up,
                    Vector3.zero);
            _createdFireParticleSystemEffect.Play();
        }

        public void SendFireEffectToPool()
        {
            if (_createdFireParticleSystemEffect)
            {
                _createdFireParticleSystemEffect.BasePoolItem.AddObjToPool(_createdFireParticleSystemEffect);
                _createdFireParticleSystemEffect = null;
            }
        }

        public void SendIcePrisonEffectToPool()
        {
            if (_createdIcePrison)
            {
                _createdIcePrison.BasePoolItem.AddObjToPool(_createdIcePrison);
                _createdIcePrison = null;
            }
        }
    }
}