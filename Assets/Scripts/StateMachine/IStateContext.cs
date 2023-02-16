namespace StateMachine
{
    public interface IStateContext
    {
        public int TypeParams { get; set; }
        public GameNode CurrentTargetNode { get; set; }
        public GameMap GetCurrentLevel();
    }
}