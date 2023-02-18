using StateMachine;
using UnityEngine;

public class GameMap : MonoBehaviour, IStateContext
{
    public int CurrentQuantityNodes { get; set; }
    public int MaxQuantityNodes { get; set; }
    public int TypeParams { get; set; }
    public GameNode CurrentTargetNode { get; set; }
    public GameNode[] GameNodes { get; set; }
}