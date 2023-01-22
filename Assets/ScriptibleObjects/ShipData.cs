using System.Collections;
using System.Collections.Generic;
using Ship;
using UnityEngine;

namespace Einar.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Ship Data", menuName = "Einar's/Ship Data")]
    public class ShipData : ScriptableObject
    {      
        [SerializeField] float throttlePower;
        [SerializeField] float rotationPower;
        [SerializeField] int healthAmount;
        [SerializeField] float laserSpeed;
        [SerializeField] float laserCooldown;
        [SerializeField] Laser laserPrefab;
        
        public float ThrottlePower => throttlePower;
        public float RotationPower => rotationPower;
        public int HealthAmount => healthAmount;
        public float LaserSpeed => laserSpeed;
        public float LaserCooldown => laserCooldown;

        public Laser LaserPrefab => laserPrefab;


        public void SetThrottlePower(float newValue) => throttlePower = newValue;
        public void SetRotationPower(float newValue) => rotationPower = newValue;
        public void SetHealthAmount(int newValue) => healthAmount = newValue;

        public void SetLaserSpeed(float newValue) => laserSpeed = newValue;
        public void SetLaserCooldown(float newValue) => laserCooldown = newValue;
        public void SetLaserPrefab(Laser newValue) => laserPrefab = newValue;
        
    }
}
