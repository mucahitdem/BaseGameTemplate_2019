using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.EnemyManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.InteractionManagement
{
    public class PlayerInteractionManager : BaseInteractionManager
    {
        private Transform _collidedTransform;

        private BaseEnemyManager _enemy;
        private PlayerManager _player;

        [SerializeField]
        private float durationToDisableInteraction;

        public Action onInteractedWithEnemy;

        // [SerializeField]
        // private Timer timer;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _player = (PlayerManager) baseComponent;
        }

        private void Start()
        {
            //timer.UpdateInitialValue(durationToDisableInteraction);
        }

        // public override void SubscribeEvent()
        // {
        //     base.SubscribeEvent();
        //     timer.onTimerEnded += OnTimerEnded;
        // }
        //
        // public override void UnsubscribeEvent()
        // {
        //     base.UnsubscribeEvent();
        //     timer.onTimerEnded -= OnTimerEnded;
        // }

        private void OnCollisionEnter(Collision other)
        {
            _collidedTransform = other.transform;
            if (_collidedTransform.CompareTag(Defs.TAG_ENEMY))
                if (_collidedTransform.TryGetComponent(out _enemy))
                    onInteractedWithEnemy?.Invoke();
        }

        public void DisableInteractionForTime()
        {
            //timer.RestartTimer();
            _player.Go.layer = LayerMask.NameToLayer(Defs.LAYER_NOT_INTERACT_WITH_ENEMY);
        }


        private void OnTimerEnded()
        {
            _player.Go.layer = LayerMask.NameToLayer(Defs.LAYER_PLAYER);
        }
    }
}