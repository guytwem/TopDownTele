using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDown.Stats
{
    public class PlayerStats : MonoBehaviour
    {
        public int level = 1;
        public int xp = 0;
        public int health = 100;
        public int currentHealth = 100;
        public int rangedDmg = 1;
        public int meleeDmg = 1;
        public int mana = 100;
        public int currentMana = 100;
        private float speed;
        private float acceleration;
        
        // Start is called before the first frame update
        void Start()
        {
            speed = GetComponent<NavMeshAgent>().speed;
            acceleration = GetComponent<NavMeshAgent>().acceleration;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

