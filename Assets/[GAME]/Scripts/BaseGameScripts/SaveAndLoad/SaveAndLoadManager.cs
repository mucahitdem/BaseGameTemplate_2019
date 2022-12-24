using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SaveAndLoad
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        [ReadOnly]
        [ShowInInspector]
        private List<ISaveAndLoad> _saveAndLoads = new List<ISaveAndLoad>();
        
        private void Awake()
        {
            GetAllSaveAndLoadDataOnScene();
            DoForAllListElements(LoadAllData);
        }

        public void OnDisable()
        {
            DoForAllListElements(SaveAllData);
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

        private void DoForAllListElements(Action<ISaveAndLoad> saveOrLoad)
        {
            for (int i = 0; i < _saveAndLoads.Count; i++)
            {
                ISaveAndLoad saveAndLoad = _saveAndLoads[i];
                saveOrLoad?.Invoke(saveAndLoad);
            }
        }
        
        private void LoadAllData(ISaveAndLoad saveAndLoad)
        {
            saveAndLoad.Load();
        }

        private void SaveAllData(ISaveAndLoad saveAndLoad)
        {
            saveAndLoad.Save();
        }
    }
}