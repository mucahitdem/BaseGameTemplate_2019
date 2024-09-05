using System;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement
{
    public class BaseUiSlider : BaseUiItem
    {
        public Action<float> onValueChanged;

        
        private Slider _slider;

        public Slider Slider
        {
            get
            {
                if (!_slider)
                    _slider = GetComponent<Slider>();
                return _slider;
            }
        }        
        protected override string GetUiId()
        {
            throw new System.NotImplementedException();
        }
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (Slider)
                Slider.onValueChanged.AddListener(OnValueChanged);
            else
                Debug.LogError("NO BUTTON FOUND !!!! ");
        }
        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            if (Slider)
                Slider.onValueChanged.RemoveListener(OnValueChanged);
        }


        public void SetValue(float value)
        {
            _slider.value = value;
        }
        protected virtual void OnValueChanged(float value)
        {
            onValueChanged?.Invoke(value);
        }
    }
}