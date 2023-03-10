using UnityEngine;

namespace Controllers
{
    public class CameraMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
    
        private readonly Vector3 _direction = Vector3.right;

        private void Update()
        {
            var distance = _speed * Time.deltaTime;
            transform.position += _direction * distance;
        }
    }
}