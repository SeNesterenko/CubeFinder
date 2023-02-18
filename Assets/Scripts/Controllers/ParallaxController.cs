using UnityEngine;

namespace Controllers
{
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
            var position = _followingTarget.position;
            var delta = position - _targetPreviousPosition;

            _targetPreviousPosition = position;
            transform.position += delta * _parallaxStrength;
        }
    }
}