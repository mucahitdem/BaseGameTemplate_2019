using System;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class UiButton : UiItem
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            _button.onClick.AddListener(OnClick);
        }
        
        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            _button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            
        }
    }
}