﻿using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.EventManagement;

namespace Scripts.EventManagement
{
    public abstract class EventSubscriber : BaseMono, IEventSubscriber
    {
        public abstract void SubscribeEvent();

        public abstract void UnsubscribeEvent();

        protected virtual void OnEnable()
        {
            SubscribeEvent();
        }

        protected virtual void OnDisable()
        {
            UnsubscribeEvent();
        }
    }
}