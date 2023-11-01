using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts
{
    public class ParticleSizeController : MonoBehaviour
    {
        [Button]
        private void ModifyParticleSize(float percentageChange)
        {
            var particles = GetComponentsInChildren<ParticleSystem>(true);
            for (var i = 0; i < particles.Length; i++)
            {
                var currentParticle = particles[i];
                var mainModule = currentParticle.main;
                var percentage = percentageChange / 100;
                Debug.LogError(currentParticle.name + " /// " + mainModule.startSizeXMultiplier);
                if (mainModule.startSize3D)
                {
                    mainModule.startSizeXMultiplier *= percentage;
                    mainModule.startSizeYMultiplier *= percentage;
                    mainModule.startSizeZMultiplier *= percentage;
                }
                else
                {
                    mainModule.startSizeMultiplier *= percentage;
                }

                Debug.LogError(currentParticle.name + " /// " + mainModule.startSizeXMultiplier);
            }
        }
    }
}