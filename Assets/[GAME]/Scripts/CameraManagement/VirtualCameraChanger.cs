using System;
using System.Collections;
using Cinemachine;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.CameraManagement
{
    public class VirtualCameraChanger : SingletonMono<VirtualCameraChanger>
    {
        [SerializeField]
        private CameraAndId[] cams;

        [SerializeField]
        private float transitionDuration;
        
        
        private int _camPriority;

        protected override void OnAwake()
        {
        }

        public void ChangeActiveCamera(string camId, int priority)
        {
            var cam = CamWithId(camId);
            cam.Priority = priority;
        }

        public void SetNewTarget(string id, Transform target)
        {
            var cam = CamWithId(id);
            StartCoroutine(CameraTarget(cam, target));
        }


        private IEnumerator CameraTarget(CinemachineVirtualCamera cam, Transform target)
        {
            float elapsedTime = 0;
            var originalTarget = cam.Follow;
            var composer = cam.GetCinemachineComponent<CinemachineTransposer>();
            while (elapsedTime < transitionDuration)
            {
                composer.m_FollowOffset = Vector3.Lerp(originalTarget.position, target.position,
                    elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cam.Follow = target;
        }

        public CinemachineVirtualCamera CamWithId(string camId)
        {
            for (var i = 0; i < cams.Length; i++)
            {
                var currentCam = cams[i];
                if (currentCam.camId == camId)
                    return currentCam.cam;
            }

            return null;
        }
    }

    [Serializable]
    public struct CameraAndId
    {
        public CinemachineVirtualCamera cam;
        public string camId;
    }
}