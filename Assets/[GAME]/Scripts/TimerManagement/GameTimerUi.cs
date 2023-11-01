using System.Collections;
using Scripts.GameManagement;

namespace Scripts.GameScripts.TimerManagement
{
    public class GameTimerUi : CountDownTimerUi
    {
        protected override IEnumerator Start()
        {
            while (!countDownTimer)
            {
                countDownTimer = GameManager.Instance.GameTimer;
                yield return null;
            }

            countDownTimer.onTimeInMinutesUpdate += OnTimeInMinutesUpdate;
        }
    }
}