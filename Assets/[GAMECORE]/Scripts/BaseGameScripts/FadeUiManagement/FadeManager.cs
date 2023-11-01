using System;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.FadeUiManagement
{
    public class FadeManager : SingletonMono<FadeManager>
    {
        [SerializeField]
        private float fadeDuration;

        [SerializeField]
        private Image fadeImage;
        
        protected override void OnAwake()
        {
            
        }

        public void Fade(Action doOnFaded)
        {
            FadeIn(() =>
            {
                doOnFaded?.Invoke();
                FadeOut();
            });
        }

        private void FadeIn(Action onEnded = null)
        {
            FadeController(1, onEnded);
        }

        private void FadeOut(Action onEnded = null)
        {
            FadeController(0, onEnded);
        }

        private void FadeController(float fadeValue, Action onEnded)
        {
            //fadeImage.DOFade(fadeValue, fadeDuration).OnComplete(() => { onEnded?.Invoke(); });
        }

      
    }
}