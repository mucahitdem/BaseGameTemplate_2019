using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolingPattern<TObj> : MonoBehaviour where TObj : MonoBehaviour
    {
        private readonly Stack<TObj> _objPool = new Stack<TObj>();
        private readonly TObj _prefab;
        private readonly HideFlags _hide;

        public PoolingPattern(TObj prefab, int count, HideFlags hideFlags = HideFlags.HideInHierarchy)
        {
            _hide = hideFlags;
            this._prefab = prefab;
            FillPool(count);
        }
        private void FillPool(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var obje = Instantiate(_prefab);
                obje.gameObject.hideFlags = _hide;
                AddObjToPool(obje);
            }
        }

        public TObj PullObjFromPool()
        {
            if (_objPool.Count > 0)
            {
                var obje = _objPool.Pop();
                obje.gameObject.SetActive(true);

                return obje;
            }

            return Instantiate(_prefab);
        }
        public void AddObjToPool(TObj objToPool)
        {
            objToPool.gameObject.SetActive(false);
            _objPool.Push(objToPool);
        }
    }
}