using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] protected Owner _owner;
    
        private Vector2 _target;
        private UnityEvent _destroy = new UnityEvent();

        public Owner Launched => _owner;

        private void Start()
        {
            _destroy.AddListener(delegate { Destroy(transform.gameObject); });
            _target = transform.position;

            if (_owner == Owner.Player) _target  = Vector2.up;
            else _target  = Vector2.down;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.AddForce(_target * _speed);
        }
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            _destroy.Invoke();
        }
    
        public enum Owner
        {
            Player,
            Enemies
        }
    }
}
