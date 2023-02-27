using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : SingletonMono<PoolManager>
    {
        private Dictionary<string, Pool> idAndPool;
        
        [SerializeField]
        public Pool coinPool;
        
        [SerializeField]
        public Pool brickPool;
        
        [SerializeField]
        public Pool brickHolderPool;

        protected override void OnAwake()
        {
            idAndPool = new Dictionary<string, Pool>();
            
            // idAndPool.Add(Defs.POOL_BRICK, brickPool);
            // idAndPool.Add(Defs.POOL_BRICK_HOLDER, brickHolderPool);
        }

        public BaseComponent SpawnItem(string poolId)
        {
            Pool pool = GetPool(poolId);
            return pool.pool.Pull();
        }
        
        public void DeSpawnItem(string poolId, BaseComponent comp)
        {
            Pool pool = GetPool(poolId); 
            pool.pool.Push(comp);
        }

        private Pool GetPool(string poolId)
        {
            if (idAndPool.TryGetValue(poolId, out Pool pool))
                return pool;
                
            return null;
        }
    }
}