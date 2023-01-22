using System;
using Asteroids;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Einar.ScriptableObjects;
using Ship;
using Object = UnityEngine.Object;


//remove ship and asteroid Dependencies!!!
namespace Editor
{
    public class GameSettingsWindow : EditorWindow
    {
        [SerializeField] VisualTreeAsset visualTreeAsset;
        [SerializeField] SpawnerData spawnerData;
        [SerializeField] ShipData shipData;
        [SerializeField] Asteroid asteroidPrefab;
        [MenuItem("Tool Dev/Game Settings")]
        public static void ShowEditor()
        {
            var window = GetWindow<GameSettingsWindow>();
            window.titleContent = new GUIContent("Game Settings");
        }

        
        void CreateGUI()
        {
            visualTreeAsset.CloneTree(rootVisualElement);
            if (spawnerData != null)
            {
                GrabValuesFromSpawnerData();
                UpdateSpawnerData();
            }

            if (shipData != null)
            {
                GrabValuesFromShipData();
                UpdateShipData();
            }

            if (asteroidPrefab!=null)
            {
                GrabValuesFromAsteroidPrefab();
                UpdateAsteroidPrefab();
            }
        }

        #region AsteroidPrefab

        void GrabValuesFromAsteroidPrefab()
        {
            rootVisualElement.Q<Slider>("AsteroidForceMin").value = asteroidPrefab.MinForce;
            rootVisualElement.Q<Slider>("AsteroidForceMax").value = asteroidPrefab.MaxForce;
            rootVisualElement.Q<Slider>("AsteroidSizeMin").value = asteroidPrefab.MinSize;
            rootVisualElement.Q<Slider>("AsteroidSizeMax").value = asteroidPrefab.MaxSize;
            rootVisualElement.Q<Slider>("AsteroidTorqueMin").value = asteroidPrefab.MinTorque;
            rootVisualElement.Q<Slider>("AsteroidTorqueMax").value = asteroidPrefab.MaxTorque;
        }
        void UpdateAsteroidPrefab()
        {
            rootVisualElement.Q<Slider>("AsteroidForceMin").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Force, true, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
            rootVisualElement.Q<Slider>("AsteroidForceMax").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Force, false, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
            rootVisualElement.Q<Slider>("AsteroidSizeMin").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Size, true, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
            rootVisualElement.Q<Slider>("AsteroidSizeMax").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Size, false, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
            rootVisualElement.Q<Slider>("AsteroidTorqueMin").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Torque, true, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
            rootVisualElement.Q<Slider>("AsteroidTorqueMax").RegisterValueChangedCallback(evt =>
            {
                asteroidPrefab.SetFloat(Asteroid.FloatReference.Torque, false, evt.newValue);
                SaveChanges(asteroidPrefab, false);
            });
        }

        #endregion


        #region SpawnerData

        void GrabValuesFromSpawnerData()
        {
            rootVisualElement.Q<Slider>("SpawnTimeMin").value = spawnerData.MinSpawnTime;
            rootVisualElement.Q<Slider>("SpawnTimeMax").value = spawnerData.MaxSpawnTime;
            rootVisualElement.Q<SliderInt>("SpawnAmountMin").value = spawnerData.MinSpawnAmount;
            rootVisualElement.Q<SliderInt>("SpawnAmountMax").value = spawnerData.MaxSpawnAmount;

            rootVisualElement.Q<ObjectField>("AsteroidPrefab").value = spawnerData.AsteroidPrefab;
        }

        void UpdateSpawnerData()
        {
            rootVisualElement.Q<Slider>("SpawnTimeMin").RegisterValueChangedCallback(evt =>
            {
                spawnerData.SetMinSpawnTime(evt.newValue);
                SaveChanges(spawnerData);
            });
            rootVisualElement.Q<Slider>("SpawnTimeMax").RegisterValueChangedCallback(evt =>
            {
                spawnerData.SetMaxSpawnTime(evt.newValue);
                SaveChanges(spawnerData);
            });
            rootVisualElement.Q<SliderInt>("SpawnAmountMin").RegisterValueChangedCallback(evt =>
            {
                spawnerData.SetMinSpawnAmount(evt.newValue);
                SaveChanges(spawnerData);
            });
            rootVisualElement.Q<SliderInt>("SpawnAmountMax").RegisterValueChangedCallback(evt =>
            {
                spawnerData.SetMaxSpawnAmount(evt.newValue);
                SaveChanges(spawnerData);
            });
            rootVisualElement.Q<ObjectField>("AsteroidPrefab").RegisterValueChangedCallback(evt =>
            {
                spawnerData.SetAsteroidPrefab((Asteroid)evt.newValue);
                SaveChanges(spawnerData);
            });
        }


        #endregion

        #region ShipData

        void GrabValuesFromShipData()
        {
            rootVisualElement.Q<Slider>("ThrottlePower").value = shipData.ThrottlePower;
            rootVisualElement.Q<Slider>("RotationPower").value = shipData.RotationPower;
            rootVisualElement.Q<SliderInt>("HealthAmount").value = shipData.HealthAmount;

            rootVisualElement.Q<Slider>("LaserSpeed").value = shipData.LaserSpeed;
            rootVisualElement.Q<Slider>("LaserCooldown").value = shipData.LaserCooldown;

            rootVisualElement.Q<ObjectField>("LaserPrefab").value = shipData.LaserPrefab;
        }

        void UpdateShipData()
        {
            rootVisualElement.Q<Slider>("ThrottlePower").RegisterValueChangedCallback(evt =>
            {
                shipData.SetThrottlePower(evt.newValue);
                SaveChanges(shipData);
            });
            rootVisualElement.Q<Slider>("RotationPower").RegisterValueChangedCallback(evt =>
            {
                shipData.SetRotationPower(evt.newValue);
                SaveChanges(shipData);

            });
            rootVisualElement.Q<SliderInt>("HealthAmount").RegisterValueChangedCallback(evt =>
            {
                shipData.SetHealthAmount(evt.newValue);
                SaveChanges(shipData);

            });
            rootVisualElement.Q<Slider>("LaserSpeed").RegisterValueChangedCallback(evt =>
            {
                shipData.SetLaserSpeed(evt.newValue);
                SaveChanges(shipData);

            });
            rootVisualElement.Q<Slider>("LaserCooldown").RegisterValueChangedCallback(evt =>
            {
                shipData.SetLaserCooldown(evt.newValue);
                SaveChanges(shipData);
            });
            rootVisualElement.Q<ObjectField>("LaserPrefab").RegisterValueChangedCallback(evt =>
            {
                shipData.SetLaserPrefab((Laser)evt.newValue);
                SaveChanges(shipData);
            });
        }

        #endregion


        void SaveChanges(Object obj, bool saveAsset = true)
        {
            EditorUtility.SetDirty(obj);
            if (!saveAsset)
            {
                return;
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}