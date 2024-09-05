using System.Collections.Generic;
using Scripts.ServiceLocatorModule;
using UnityEngine;

namespace Scripts.UpdateManagement
{
    [DefaultExecutionOrder(1000)]
    public class UpdateManager : MonoBehaviour
    {
        private readonly List<IUpdate> _allObjToUpdate = new List<IUpdate>();
        

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService(this);
        }

        private void Update()
        {
            if (_allObjToUpdate.Count == 0)
                return;
            for (int i = 0; i < _allObjToUpdate.Count; i++)
            {
                _allObjToUpdate?[i].OnUpdate();
            }
        }

        
        
        
        public void Register(IUpdate objToUpdate)
        {
            if(_allObjToUpdate.Contains(objToUpdate))
               return;
            
            _allObjToUpdate.Add(objToUpdate);
        }
        public void Unregister(IUpdate objToUpdate)
        {
            if(!_allObjToUpdate.Contains(objToUpdate))
                return;
            
            _allObjToUpdate.Remove(objToUpdate);
        }
    }
}