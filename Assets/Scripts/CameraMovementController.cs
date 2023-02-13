using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    
    private Camera _camera;
    public Vector3 direction = Vector3.right;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var distance = _speed * Time.deltaTime;
        transform.position += direction * distance;
    }
}