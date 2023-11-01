using System;
using Cysharp.Threading.Tasks;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement.LightningManagement
{
    public class LightningCreator : BaseComponent
    {
        private int _convertedDuration;
        private float _dist;

        [SerializeField]
        private BasePoolItem basePoolItem;

        [SerializeField]
        private float effectDuration;

        [SerializeField]
        private ParticleSystem[] lightningEffects;

        [SerializeField]
        private ParticleSystem mainLightEffect;

        public BasePoolItem BasePoolItem => basePoolItem;

        protected override void OnEnable()
        {
            base.OnEnable();
            _convertedDuration = (int) (effectDuration * 1000);
        }

        [Button]
        public void SetTarget(Transform target, int damage, Action onLightningEnded, bool raiseAction = false)
        {
            // _dist = Vector3.Distance(TransformOfObj.position, target.position + Vector3.up);
            // _dist /= 2f;
            TransformOfObj.LookAt(target);
            // var main = mainLightEffect.main;
            // var xAndZValue = _dist * 4 / 5f;
            //main.startSizeX = xAndZValue;
            //main.startSizeY = _dist;
            //main.startSizeZ = xAndZValue;
            for (var i = 0; i < lightningEffects.Length; i++) lightningEffects[i].Play();
            if (raiseAction)
                LightningActionManager.onLightningRicocheted?.Invoke(target.position, damage);

            OnLightEffectEnded(onLightningEnded).GetAwaiter();
        }

        private async UniTask OnLightEffectEnded(Action onLightningEnded)
        {
            await UniTask.Delay(_convertedDuration);
            onLightningEnded?.Invoke();
            // var electro = electroChargesEffect.BasePoolItem.PullObjFromPool<ElectroChargesEffect>(TransformOfObj.position);
            // electro.Play();
            BasePoolItem.AddObjToPool(this);
        }
    }
}