using StateMachine;
using UnityEngine;

public class GameMap : MonoBehaviour, IStateContext
{
    public int TypeParams { get; set; }
    public GameNode CurrentTargetNode { get; set; }
    public GameNode[] GameNodes { get; set; }
    
    public GameMap GetCurrentLevel()
    {
        return this;
    }
}