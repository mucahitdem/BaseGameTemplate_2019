using System.Collections;
using DG.Tweening;
using Scripts.BaseGameScripts.EventManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.StatsManagement.StatsUiManagement
{
    public class StatsUiBar : EventSubscriber
    {
        private Image[] allImages;

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private Image fillBar;

        private bool lastAlpha;

        [SerializeField]
        private BaseStatsManager statsManager;

        private Coroutine tempCor;

        private void Awake()
        {
            allImages = GetComponentsInChildren<Image>();
            lastAlpha = true;
        }

        public void ResetBar()
        {
            fillBar.fillAmount = 1;
        }

        public override void SubscribeEvent()
        {
            statsManager.onHealthUpdate += OnHealthUpdate;
            statsManager.onDied += OnDied;
            statsManager.showUiBar += ShowUiBar;
        }

        public override void UnsubscribeEvent()
        {
            statsManager.onHealthUpdate -= OnHealthUpdate;
            statsManager.onDied -= OnDied;
        }


        private void ShowUiBar(bool isActive)
        {
            if (isActive == lastAlpha)
                return;
            lastAlpha = isActive;
            var alpha = isActive ? 1 : 0;
            if (tempCor != null)
                StopCoroutine(tempCor);
            tempCor = StartCoroutine(FadeImage(alpha));
        }

        private IEnumerator FadeImage(float endAlpha)
        {
            float elapsedTime = 0;
            var fadeDuration = 1f;
            while (elapsedTime < fadeDuration)
            {
                // Calculate the alpha value using Lerp
                var alpha = Mathf.Lerp(endAlpha > 0f ? 0 : 1, endAlpha, elapsedTime / fadeDuration);

                // Update the CanvasGroup alpha
                canvasGroup.alpha = alpha;

                // Increment the elapsed time
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            canvasGroup.alpha = endAlpha;
        }

        private void OnDied(float cart)
        {
            //DOTween.Kill("Transition");
            //gameObject.SetActive(false);
        }

        private void OnHealthUpdate(float health, float ratio)
        {
            DOTween.Kill("Transition");
            var currentAmount = fillBar.fillAmount;
            DOTween.To(() => currentAmount, x => currentAmount = x, ratio, .15f).SetId("Transition")
                .OnUpdate(() => fillBar.fillAmount = currentAmount);
        }
    }
}