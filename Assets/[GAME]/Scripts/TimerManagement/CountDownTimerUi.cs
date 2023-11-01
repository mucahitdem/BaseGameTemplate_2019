using System.Collections;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using TMPro;
using UnityEngine;

namespace Scripts.GameScripts.TimerManagement
{
    public abstract class CountDownTimerUi : BaseUiItem
    {
        protected CountDownTimer countDownTimer;

        [SerializeField]
        private TextMeshProUGUI gameTimerText;

        protected virtual IEnumerator Start()
        {
            yield return null;
        }


        protected override string GetUiId()
        {
            return Defs.UI_KEY_GAME_TIMER;
        }

        protected void OnTimeInMinutesUpdate(string time)
        {
            gameTimerText.text = time;
        }
    }
}