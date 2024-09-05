using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UiManagement.BaseUiItemManagement
{
    public class BaseToggleUi : BaseUiItem
    {
        public Action<BaseToggleUi, bool> onValueChanged;

        public Toggle Toggle => toggle;
        
        [SerializeField]
        private Toggle toggle;

        [SerializeField]
        private TextMeshProUGUI toggleLabel;
        
        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
        
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (toggle)
                toggle.onValueChanged.AddListener(OnToggleValueChanged);
            else
                Debug.LogError("NO BUTTON FOUND !!!! ");
        }
        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            if (toggle)
                toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }


        public void SetLabel(string label)
        {
            toggleLabel.text = label;
        }

        protected virtual void OnToggleValueChanged(bool isSelected)
        {
            onValueChanged?.Invoke(this, isSelected);
        }
    }
}