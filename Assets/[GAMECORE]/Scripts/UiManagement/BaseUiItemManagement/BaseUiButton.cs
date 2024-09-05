using System;
using GAME.Scripts.SoundManagement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UiManagement.BaseUiItemManagement
{
    public abstract class BaseUiButton : BaseUiItem
    {
        [SerializeField]
        private bool playSoundOnTap = true;

        [SerializeField]
        private bool useCustomSound;

        [ShowIf("useCustomSound")]
        [SerializeField]
        private string audioId;
        
        private Button _button;
        public Button Button
        {
            get
            {
                if (!_button)
                    _button = GetComponent<Button>();
                return _button;
            }
            private set => _button = value;
        }

        
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (Button)
                Button.onClick.AddListener(OnClick);
            else
            {
                Button = gameObject.AddComponent<Button>();
                Button.onClick.AddListener(OnClick);
                Debug.LogError(transform.name + " NO BUTTON FOUND. ADDED VIA CODE");
            }
        }
        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            if (Button)
                Button.onClick.RemoveListener(OnClick);
        }

        
        protected virtual void OnClick()
        {
            PlaySound();
            onClick?.Invoke();
        }
        protected override string GetUiId()
        {
            return "";
        }
        protected virtual void PlaySound()
        {
            if(!playSoundOnTap)
                return;
            if(soundManager)
                soundManager.PlayAudio(useCustomSound ? audioId : SoundManager.AUDIO_BUTTON_CLICK);
        }
    }
}