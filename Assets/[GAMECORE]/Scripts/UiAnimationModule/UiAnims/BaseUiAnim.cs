using System;
using GAME.Scripts.UiAnimationModule;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;

namespace Scripts.UiAnimationModule.UiAnims
{
    public abstract class BaseUiAnim : MonoBehaviour
    {
        public AnimPlayMoment AnimPlayMoment => animPlayMoment;
        
        [SerializeField]
        private AnimPlayMoment animPlayMoment;

        public virtual void Init(BaseUiItem uiItem)
        {
            
        }
        public abstract void PlayAnimSeq(BaseUiItem target, Action onComplete);
    }
}