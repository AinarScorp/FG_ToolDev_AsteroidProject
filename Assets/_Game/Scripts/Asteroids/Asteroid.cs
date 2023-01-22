using System;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt _onAsteroidDestroyed;
        
        [Header("Config:")]
        [SerializeField][HideInInspector] float _minForce;
        [SerializeField][HideInInspector] float _maxForce;
        [SerializeField][HideInInspector] float _minSize;
        [SerializeField][HideInInspector] float _maxSize;
        [SerializeField][HideInInspector] float _minTorque;
        [SerializeField][HideInInspector] float _maxTorque;

        public enum FloatReference
        {
            Force, Size, Torque
        }
        [Header("References:")]
        [SerializeField] private Transform _shape;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceId;

        public float MinForce => _minForce;
        public float MaxForce => _maxForce;
        public float MinSize => _minSize;
        public float MaxSize => _maxSize;
        public float MinTorque => _minTorque;
        public float MaxTorque => _maxTorque;

        public void SetFloat(FloatReference floatReference, bool setMin, float newValue)
        {
            switch (floatReference)
            {
                case FloatReference.Force:
                    if (setMin)
                    {
                        _minForce = newValue;
                    }
                    else
                    {
                        _maxForce = newValue;
                    }
                    break;
                case FloatReference.Size:
                    
                    if (setMin)
                    {
                        _minSize = newValue;
                    }
                    else
                    {
                        _maxSize = newValue;
                    }                    break;
                case FloatReference.Torque:
                    if (setMin)
                    {
                        _minTorque = newValue;
                    }
                    else
                    {
                        _maxTorque = newValue;
                    }                    
                    break;
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _instanceId = GetInstanceID();
            
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
               HitByLaser();
            }
        }

        private void HitByLaser()
        {
            _onAsteroidDestroyed.Raise(_instanceId);
            Destroy(gameObject);
        }

        // TODO Can we move this to a single listener, something like an AsteroidDestroyer?
        public void OnHitByLaser(IntReference asteroidId)
        {
            if (_instanceId == asteroidId.GetValue())
            {
                Destroy(gameObject);
            }
        }
        
        public void OnHitByLaserInt(int asteroidId)
        {
            if (_instanceId == asteroidId)
            {
                Destroy(gameObject);
            }
        }
        
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            var size = Random.Range(_minSize, _maxSize);
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
