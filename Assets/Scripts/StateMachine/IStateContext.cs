namespace StateMachine
{
    public interface IStateContext
    {
        public int CurrentQuantityNodes { get; }
        public int MaxQuantityNodes { get; }
        public int TypeParams { get; }
        public GameNode CurrentTargetNode { get; }
    }
}