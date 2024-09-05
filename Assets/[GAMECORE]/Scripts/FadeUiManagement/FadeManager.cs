using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.FadeUiManagement
{
    public class FadeManager : MonoBehaviour
    {
        [SerializeField]
        private float fadeDuration;

        [SerializeField]
        private Image fadeImage;
        
        
        
        public void Fade(Action doOnFaded)
        {
            fadeImage.raycastTarget = true;
            FadeIn(() =>
            {
                doOnFaded?.Invoke();
                FadeOut(()=> fadeImage.raycastTarget = false);
            });
        }
        public void FadeIn(Action onEnded = null)
        {
            FadeController(1, onEnded);
        }
        public void FadeOut(Action onEnded = null)
        {
            FadeController(0, onEnded);
        }
        
        
        
        
        private void FadeController(float fadeValue, Action onEnded)
        {
            fadeImage.raycastTarget = true;
            fadeImage.DOFade(fadeValue, fadeDuration).OnComplete(() =>
            {
                fadeImage.raycastTarget = false;
                onEnded?.Invoke();
            });
        }
    }
}