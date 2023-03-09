namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState02_0Playing : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen("gamePlayScreen");
        }

        public override void ExitState()
        {
        }
    }
}