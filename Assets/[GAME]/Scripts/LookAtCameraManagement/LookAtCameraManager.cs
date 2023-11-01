using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.LookAtCameraManagement
{
    public class LookAtCameraManager : SingletonMono<LookAtCameraManager>
    {
        private readonly List<Transform> objs = new List<Transform>();

        [SerializeField]
        private Camera cam;

        private Vector3 camPos;

        protected override void OnAwake()
        {
            if (cam)
                camPos = cam.transform.position;
            //cam = Camera.main;
        }

        private void Start()
        {
            if (cam)
                camPos = cam.transform.position;
        }

        private void Update()
        {
            if (objs.Count == 0 || cam == null)
                return;
            for (var i = 0; i < objs.Count; i++)
            {
                var currentObj = objs[i];
                var direction = camPos - currentObj.position;

                //direction.x = currentObj.forward.x;
                //direction.x = 0;
                direction.y = 0;
                //direction.y = currentObj.forward.y;
                currentObj.forward = cam.transform.forward;
                //currentObj.rotation = Quaternion.LookRotation(direction);

                //objs[i].LookAt(cam.transform);
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