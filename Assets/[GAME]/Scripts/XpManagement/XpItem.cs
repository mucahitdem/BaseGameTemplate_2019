using System.Collections;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.XpManagement
{
    public class XpItem : BaseComponent
    {
        private Coroutine _cor;

        private Transform _target;

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private BasePoolItem poolItem;

        public BasePoolItem PoolItem => poolItem;

        [ShowInInspector]
        [ReadOnly]
        public float Xp { get; private set; }


        protected override void OnEnable()
        {
            base.OnEnable();
            Go.layer = LayerMask.NameToLayer(Defs.LAYER_XP_SPHERE);
        }


        public void LoadXp(float xpToLoad)
        {
            Xp = xpToLoad;
        }

        public void MoveToPlayer(Transform target)
        {
            Go.layer = LayerMask.NameToLayer(Defs.LAYER_INTERACT_WTIH_NOTHING);
            _target = target;
            _cor = StartCoroutine(Move());
        }


        private IEnumerator Move()
        {
            while (!IsReached())
            {
                MoveToTarget();

                yield return null;
            }

            XpCollectActionManager.onCollectedXp?.Invoke(Xp);
            PoolItem.AddObjToPool(this);
            //Go.SetActive(false); // pool a yoıllanacak
            //StopCoroutine(_cor);
            yield return null;
        }

        private bool IsReached()
        {
            if (!_target)
                return false;

            return Vector3.Distance(_target.position, TransformOfObj.position) < .5f;
        }

        private void MoveToTarget()
        {
            TransformOfObj.LookAt(_target);
            TransformOfObj.position += TransformOfObj.forward * (Time.deltaTime * moveSpeed);
        }
    }
}