using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class PersistenObjects : MonoBehaviour
    {
        [SerializeField] GameObject persistenObjectPrefab;

        public static bool hasSpawned = false;


        private void Awake()
        {
            if (hasSpawned) return;
            SpawnPersistenObjects();

            hasSpawned = true;
        }

        private void SpawnPersistenObjects()
        {
            GameObject persistenObject = Instantiate(persistenObjectPrefab);
            DontDestroyOnLoad(persistenObject);
        }
    }
}