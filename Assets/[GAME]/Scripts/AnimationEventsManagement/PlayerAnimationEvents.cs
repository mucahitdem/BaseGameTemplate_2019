using System;
using Scripts.GameScripts.AnimationEventsManagement;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts.AnimationEventsManagement
{
    public class PlayerAnimationEvents : AnimationEvents
    {
        public ParticleSystem leftLegParticle;
        public Transform playerTransform;
        public ParticleSystem rightLegParticle;

        [SerializeField]
        private AudioSource source;

        [Obsolete("Obsolete")]
        public void RightLeg()
        {
            rightLegParticle.startRotation = -playerTransform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            source.Play();
            rightLegParticle.Play();
        }

        [Obsolete("Obsolete")]
        public void LeftLeg()
        {
            leftLegParticle.startRotation = -playerTransform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            source.Play();
            leftLegParticle.Play();
        }
    }
}