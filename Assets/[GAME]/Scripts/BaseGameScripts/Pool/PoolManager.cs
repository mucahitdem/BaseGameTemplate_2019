using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [ReadOnly]
        [ShowInInspector]
        public List<Type> poolObjects = new List<Type>();
        
        private void Awake()
        {
            CreatePoolObjects();
        }

        private void CreatePoolObjects()
        {
            List<Type> subClasses = AssemblyManager.GetClassesImplementedInterface(typeof(IPoolObject));
            
            for (int i = 0; i < subClasses.Count; i++)
            {
                Type currentType = subClasses[i];
                Debug.LogError(currentType.Name);
                
                poolObjects.Add(currentType);
            }
        }
    }
}