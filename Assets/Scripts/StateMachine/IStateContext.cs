using UnityEngine;

namespace StateMachine
{
    public interface IStateContext
    {
        public Canvas GetCurrentGameScreen();
        public GameNode[] GetCurrentLevelGameNodes();
        public GameNode GetCurrentLevelTargetNode();
        public GameNode GetPreviousTargetNode();
        public GameMap GetNextLevel();
    }
}