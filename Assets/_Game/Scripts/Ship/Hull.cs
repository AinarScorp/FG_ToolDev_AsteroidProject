using System;
using DefaultNamespace.ScriptableEvents;
using Einar.ScriptableObjects;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        int currentHealth;
        void Awake()
        {
            ShipData shipData = Resources.Load<ShipData>("GameData/Ship Data");
            if (shipData == null)
            {
                Debug.LogError("Ship data is not found");
                return;
            }

            currentHealth = shipData.HealthAmount;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
                ApplyDamage();
            }
        }

        void ApplyDamage()
        {
            Debug.Log("Hull collided with Asteroid");
            currentHealth--;
            if (currentHealth <= 0)
            {
                Debug.Log("GAME IS OVER");
            }
        }
    }
}
