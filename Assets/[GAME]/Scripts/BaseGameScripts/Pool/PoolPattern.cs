using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolPattern : MonoBehaviour
    {
        private readonly Stack<BaseComponent> pool = new Stack<BaseComponent>(); 
        private readonly BaseComponent prefab;
        private readonly HideFlags hideFlag;
        
        private int counter;
        
        public PoolPattern(BaseComponent prefab, int itemCount, HideFlags hideFlag)
        {
            this.prefab = prefab;
            this.hideFlag = hideFlag;
            
            FillPool(itemCount);
        }
        
        private void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                DebugHelper.LogGreen("CREATED " + prefab.name);
                BaseComponent obj = Instantiate(prefab);
                obj.hideFlags = hideFlag;
                Push(obj);
            }
        }
        public BaseComponent Pull()
        {
            return PullOjb();
        }
        
        public T Pull<T>() where T : BaseComponent
        {
            return (T)PullOjb();
        }

        private BaseComponent PullOjb()
        {
            BaseComponent obj = null;
            
            if (!PoolIsEmpty())
                obj = pool.Pop();
            else
            {
                obj = Instantiate(prefab);
                obj.name += counter.ToString();
                counter++;
            }
            
            obj.OnGetFromPool();
            
            return obj;
        }

        public void Push(BaseComponent obj)
        {
            obj.OnGiveToPool();
            pool.Push(obj);
        }
        private bool PoolIsEmpty()
        {
            return pool.Count == 0;
        }
    }
}