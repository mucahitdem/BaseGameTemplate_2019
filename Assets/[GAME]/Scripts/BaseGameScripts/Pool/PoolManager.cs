using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        private List<IPoolObject> _poolObjects = new List<IPoolObject>();
        private void Awake()
        {
            CreatePoolObjects();
        }

        private void CreatePoolObjects()
        {
            List<Type> subClasses = AssemblyManager.GetSubClassesOfType(typeof(IPoolObject));
            
            for (int i = 0; i < subClasses.Count; i++)
            {
                Type currentType = subClasses[i];
                
                var stateBehaviour = (IPoolObject) gameObject.AddComponent(currentType);
                _poolObjects.Add(stateBehaviour);
            }
        }
    }
}