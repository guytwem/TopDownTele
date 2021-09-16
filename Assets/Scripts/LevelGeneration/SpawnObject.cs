using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace TopDown.LevelGeneration
{
    public class SpawnObject : MonoBehaviour
    {
        public GameObject[] objects;
        private int rand;
        private void Start()
        {
            rand = Random.Range(0, objects.Length);
            GameObject instance = (GameObject) Instantiate(objects[rand], transform.position, Quaternion.identity);
            instance.transform.parent = transform;
        }
    } 
}

