using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDown.LevelGeneration;

namespace TopDown.LevelGeneration
{
    public class SpawnRoom : MonoBehaviour
    {
        public LayerMask whatIsRoom;
        public LevelGenerator levelGen;
        private void Update()
        {
            Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
            if(roomDetection == null && levelGen.stopGeneration == true)
            {
                int rand = Random.Range(0, levelGen.rooms.Length);
                Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}