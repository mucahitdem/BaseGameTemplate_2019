using System;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.SourceManagement
{
    public class ClampedSourceUi : BaseUiItem
    {
        [SerializeField]
        private ClampedSourceDataSo clampedSourceDataSo;

        [SerializeField]
        private TextMeshProUGUI sourceAmount;

        [SerializeField]
        private Image sourceIcon;

        [SerializeField]
        private Image fillBar;

        private float _maxAmount;

        private void Awake()
        {
            if(sourceIcon)
                sourceIcon.sprite = clampedSourceDataSo.baseSourceData.sourceIcon;
            if(sourceAmount)
                sourceAmount.text = clampedSourceDataSo.baseSourceData.initialSourceCount + "/" + _maxAmount;
            
            _maxAmount = clampedSourceDataSo.clampedSourceData.maxSourceAmount;
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SourceActionManager.onClampedSourceUpdated += OnClampedSourceUpdated;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SourceActionManager.onClampedSourceUpdated -= OnClampedSourceUpdated;
        }
        
        
        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
        
        
        private void OnClampedSourceUpdated(ClampedSourceDataSo sourceDataSo, int currentSource)
        {
            var ratio = currentSource / _maxAmount;
            if(sourceAmount)
                sourceAmount.text = currentSource + "/" + _maxAmount;
            if(fillBar)
                fillBar.fillAmount = ratio;
        }
    }
}