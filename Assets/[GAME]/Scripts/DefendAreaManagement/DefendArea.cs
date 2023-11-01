using System;
using _GAME_.Scripts.GameScripts.DefendAreaManagement;
using _GAME_.Scripts.GameScripts.SoundManagement;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.DefendAreaManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.DefendAreaManagement
{
    public class DefendArea : BaseComponent
    {
        [SerializeField]
        private InteractionChecker activateArea;

        [SerializeField]
        private InteractionChecker defendArea;

        [SerializeField]
        private DefendAreaCapturePositionManager defendAreaCapturePositionManager;

        [SerializeField]
        private DefendAreaSoldierManager defendAreaSoldierManager;

        [SerializeField]
        [ReadOnly]
        private bool isCaptured;

        public Action OnCaptured;

        public Transform TargetCapturePos => defendAreaCapturePositionManager.CurrentPos();

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            defendAreaSoldierManager.OnAllEnemiesDied += OnAllEnemiesDied;
            activateArea.onEnteredArea += OnEnteredActivateArea;
            activateArea.onExitArea += OnExitActivateArea;
            defendArea.onEnteredArea += OnEnteredDefendArea;
            defendArea.onExitArea += OnExitDefendArea;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            defendAreaSoldierManager.OnAllEnemiesDied -= OnAllEnemiesDied;
            activateArea.onEnteredArea -= OnEnteredActivateArea;
            activateArea.onExitArea -= OnExitActivateArea;
            defendArea.onEnteredArea -= OnEnteredDefendArea;
            defendArea.onExitArea -= OnExitDefendArea;
        }


        public void ResetDefendArea()
        {
            defendAreaSoldierManager.DisableAllSoldiers();
        }

        private void OnAllEnemiesDied()
        {
            isCaptured = true;
            OnCaptured?.Invoke();
            SoundManager.Instance.PlayGlobalAudio(Defs.AUDIO_WIN_BATTLE);
            enabled = false;
            UnsubscribeEvent();
        }

        public void OnEnteredActivateArea()
        {
            if (isCaptured)
                return;
            defendAreaSoldierManager.EnableSoldiers();
        }

        private void OnExitActivateArea()
        {
            if (isCaptured)
                return;
            defendAreaSoldierManager.Defend();
            //defendAreaSoldierManager.DisableSoldiers();
        }

        private void OnEnteredDefendArea()
        {
            if (isCaptured)
                return;
            defendAreaSoldierManager.Attack();
        }

        private void OnExitDefendArea()
        {
            if (isCaptured)
                return;
        }
    }

    [Serializable]
    public struct RadiusAndColor
    {
        public SphereCollider sphereCollider;
        public float radius;
        public Color gizmoColor;
    }
}