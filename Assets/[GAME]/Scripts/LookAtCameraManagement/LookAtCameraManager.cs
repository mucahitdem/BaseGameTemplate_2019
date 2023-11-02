using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.LookAtCameraManagement
{
    public class LookAtCameraManager : SingletonMono<LookAtCameraManager>
    {
        private readonly List<Transform> objs = new List<Transform>();

        [SerializeField]
        private Camera cam;
        
        protected override void OnAwake()
        {
        }
        private void Update()
        {
            if (objs.Count == 0 || cam == null)
                return;
            for (var i = 0; i < objs.Count; i++)
            {
                var currentObj = objs[i];
                currentObj.forward = cam.transform.forward;
            }
        }

        public void AddObj(Transform objToAdd)
        {
            if (objs.Contains(objToAdd))
                return;

            objs.Add(objToAdd);
        }
        public void RemoveObj(Transform objToRemove)
        {
            objs.Remove(objToRemove);
        }
    }
}