using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.GameScripts.EffectManagement._BaseClasses
{
    public abstract class BaseEffect : BaseComponent
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        public BasePoolItem BasePoolItem => basePoolItem;


        public abstract void Play();

        public void RePool()
        {
            BasePoolItem.AddObjToPool(this);
        }
    }
}