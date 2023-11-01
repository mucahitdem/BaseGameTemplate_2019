using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.AllBullets
{
    public class AutoRePooler : MonoBehaviour
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        [SerializeField]
        private BaseComponent objToPool;

        [SerializeField]
        private Timer rePoolTimer;

        private void Awake()
        {
            rePoolTimer.onTimerEnded += OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            basePoolItem.AddObjToPool(objToPool);
        }
    }
}