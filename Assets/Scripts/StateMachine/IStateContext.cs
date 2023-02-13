using UnityEngine;

namespace StateMachine
{
    public interface IStateContext
    {
        public GameNode[] GetCurrentLevelGameNodes();
        public GameNode GetCurrentLevelTargetNode();
        public GameNode GetPreviousTargetNode();
        public GameMap GetNextLevel();
    }
}