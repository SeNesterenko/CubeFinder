namespace StateMachine
{
    public interface IStateContext
    {
        public int CurrentQuantityNodes { get; set; }
        public int MaxQuantityNodes { get; set; }
        public int TypeParams { get; set; }
        public GameNode CurrentTargetNode { get; set; }
        public GameMap GetCurrentLevel();
    }
}