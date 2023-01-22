using System;
using Einar.ScriptableObjects;
using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        Rigidbody2D _rigidbody;
        ShipData shipData;
        void Awake()
        {
            shipData = Resources.Load<ShipData>("GameData/Ship Data");
            if (shipData == null)
            {
                Debug.LogError("Ship data is not found");
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    
        void Throttle()
        {
            _rigidbody.AddForce(transform.up * shipData.ThrottlePower, ForceMode2D.Force);
        }

        void SteerLeft()
        {
            _rigidbody.AddTorque(shipData.RotationPower, ForceMode2D.Force);
        }

        void SteerRight()
        {
            _rigidbody.AddTorque(-shipData.RotationPower, ForceMode2D.Force);
        }
    }
}
