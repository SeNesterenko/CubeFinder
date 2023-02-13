using System;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStrength = 0.1f;

    private Vector3 _targetPreviousPosition;
    
    private void Start()
    {
        _targetPreviousPosition = transform.position;
    }

    private void Update()
    {
        var delta = _followingTarget.position - _targetPreviousPosition;

        _targetPreviousPosition = _followingTarget.position;
        transform.position += delta * _parallaxStrength;
    }
}

public class CameraMovementController : MonoBehaviour
{
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        
    }
}