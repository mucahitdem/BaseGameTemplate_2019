using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        private readonly Dictionary<string, PoolingPattern> _idAndPool = new Dictionary<string, PoolingPattern>();
        private PoolingPattern _tempPool;
        public PoolingPattern[] itemsPool;

        [SerializeField]
        private List<GameObject> poolItems;

        private void Awake()
        {
            Create();
        }

        public PoolingPattern PoolWithId(string poolId)
        {
            if (_idAndPool.TryGetValue(poolId, out _tempPool)) 
                return _tempPool;

            //DebugHelper.LogRed("THERE IS NO POOL WITH ID : " + poolId);
            return null;
        }
        public GameObject InstantiateObj(GameObject t) 
        {
            return Instantiate(t);
        }
        
        
        
        private void Create()
        {
            itemsPool = new PoolingPattern[poolItems.Count];
            for (var i = 0; i < poolItems.Count; i++)
            {
                var currentItem = poolItems[i];
                itemsPool[i] = new PoolingPattern(currentItem, 3, this);
                _idAndPool.Add(currentItem.name, itemsPool[i]);
            }
        }
    }
}