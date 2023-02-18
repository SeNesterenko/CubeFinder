using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameNode : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 5f;
    [SerializeField] private float _shakeStrength = 20f;
    [SerializeField] private int _shakeVibrato = 3;
    [SerializeField] private float _shakeRandomness = 90f;
    
    [SerializeField] private string _name;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _content;
    [SerializeField] private Image _backgroundColor;

    public void SetBackGroundColor(Color color)
    {
        _backgroundColor.color = color;
    }
    
    public string GetName()
    {
        return _name;
    }

    public Button GetButton()
    {
        return _button;
    }

    public void VibrateNode()
    {
        transform.DOShakePosition(_shakeDuration, _shakeStrength, _shakeVibrato, _shakeRandomness).
            SetLoops(-1,LoopType.Yoyo);
    }

    public void DeleteContent()
    {
        Destroy(_content);
    }
}