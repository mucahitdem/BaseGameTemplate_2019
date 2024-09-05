using System;
using DG.Tweening;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;

namespace Scripts.UiAnimationModule.UiAnims
{
    public class SlidingAnim : BaseUiAnim
    {
        [SerializeField]
        private Vector2 startPos;

        [SerializeField]
        private Vector2 endPos;

        [SerializeField]
        private float duration;
        
                
        
        public override void PlayAnimSeq(BaseUiItem target, Action onComplete)
        {
            target.RectTransformObj.anchoredPosition = startPos;
            target.RectTransformObj.DOAnchorPos(endPos, duration).SetEase(Ease.OutCirc)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
        }
    }
}