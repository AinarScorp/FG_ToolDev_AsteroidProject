using System;
using UnityEngine;
using Einar.ScriptableObjects;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        ShipData shipData;

        void Awake()
        {
            shipData = Resources.Load<ShipData>("GameData/Ship Data");
            if (shipData == null)
            {
                Debug.LogError("Ship data is not found");
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }
        
        private void Shoot()
        {
            var trans = transform;
            Instantiate(shipData.LaserPrefab, trans.position, trans.rotation).SetSpeed(shipData.LaserSpeed);
        }
    }
}
