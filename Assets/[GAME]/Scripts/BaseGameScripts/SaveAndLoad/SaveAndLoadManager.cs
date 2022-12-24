using System;
using System.Collections.Generic;
using System.Reflection;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.State;
using Scripts.State._Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.SaveAndLoad
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        [ReadOnly]
        [ShowInInspector]
        private List<ISaveAndLoad> _saveAndLoads = new List<ISaveAndLoad>();
        
        private void Awake()
        {
            GetAllSaveAndLoadDataOnScene();
        }


        private void GetAllSaveAndLoadDataOnScene()
        {
            List<Type> subClasses = AssemblyManager.GetSubClassesOfType(typeof(ISaveAndLoad));
            
            for (int i = 0; i < subClasses.Count; i++)
            {
                Type currentType = subClasses[i];
                
                var stateBehaviour = (ISaveAndLoad) gameObject.AddComponent(currentType);
                _saveAndLoads.Add(stateBehaviour);
            }
        }
    }
}