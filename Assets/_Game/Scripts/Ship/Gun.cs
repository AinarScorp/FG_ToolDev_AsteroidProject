using System;
using UnityEngine;
using Einar.ScriptableObjects;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        ShipData shipData;
        float shootCooldown;
        float timePassed;

        void Awake()
        {
            shipData = Resources.Load<ShipData>("GameData/Ship Data");
            if (shipData == null)
            {
                Debug.LogError("Ship data is not found");
            }
        }

        void Start()
        {
            if (shipData)
            {
                shootCooldown = shipData.LaserCooldown;
            }
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            if (timePassed < shootCooldown)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                timePassed = 0;
                Shoot();
            }
        }
        
        private void Shoot()
        {
            var trans = transform;
            Instantiate(shipData.LaserPrefab, trans.position, trans.rotation).SetSpeed(shipData.LaserSpeed);
        }
    }
}
