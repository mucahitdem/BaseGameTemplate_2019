using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class SpriteAnim : MonoBehaviour
    {
        [SerializeField]
        private float delayDuration;

        [SerializeField]
        private float endDuration;

        [Button]
        private void Rename()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var currentChild = transform.GetChild(i);
                currentChild.name = i.ToString();
            }
        }

        [Button]
        public void Play()
        {
            StartCoroutine(PlayAnim());
        }

        private IEnumerator PlayAnim()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var currentChild = transform.GetChild(i);
                currentChild.gameObject.SetActive(true);
                yield return new WaitForSeconds(delayDuration);
            }

            yield return new WaitForSeconds(endDuration);

            for (var i = 0; i < transform.childCount; i++)
            {
                var currentChild = transform.GetChild(i);
                currentChild.gameObject.SetActive(false);
            }
        }
    }
}