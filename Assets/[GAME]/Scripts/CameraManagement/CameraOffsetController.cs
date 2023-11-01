using System.Collections;
using Cinemachine;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.Helpers;
using UnityEngine;

namespace Scripts.CameraManagement
{
    public class CameraOffsetController : BaseComponent
    {
        private float _currentTimeValue;

        private CinemachineTransposer _transPoser;

        [SerializeField]
        private float speed;

        [SerializeField]
        private CinemachineVirtualCamera vCam;

        protected void Awake()
        {
            _transPoser = vCam.GetCinemachineComponent<CinemachineTransposer>();
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            //WeaponActionManager.increaseFireRangePercentage += ChangeOffset;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            //WeaponActionManager.increaseFireRangePercentage -= ChangeOffset;
        }


        private void ChangeOffset(float percentage)
        {
            StartCoroutine(UpdateOffset(percentage));
        }

        private IEnumerator UpdateOffset(float percentage)
        {
            var currentOffset = _transPoser.m_FollowOffset;
            var targetOffset = currentOffset + MathCalculations.CalculatePercentage(currentOffset, percentage / 2f);
            _currentTimeValue = 0f;
            while (_currentTimeValue <= 1)
            {
                _currentTimeValue += Time.deltaTime * speed;
                _transPoser.m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, _currentTimeValue);

                yield return null;
            }
        }
    }
}