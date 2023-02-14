using UnityEngine;
using UnityEngine.UI;

public class GameNode : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Button _button;
    
    public string GetName()
    {
        return _name;
    }

    public Button GetButton()
    {
        return _button;
    }
}