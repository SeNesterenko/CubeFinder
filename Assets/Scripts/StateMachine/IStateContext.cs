namespace StateMachine
{
    public interface IStateContext
    {
        public GameMap GetCurrentLevel();
        public GameNode[] GetGameNodes();
        public GameNode GetCurrentLevelTargetNode();
        public GameNode GetPreviousTargetNode();
        public GameMap GetNextLevel();
    }
}