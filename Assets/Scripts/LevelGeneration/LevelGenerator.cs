using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TopDown.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        public Transform[] startingPos;
        public GameObject[] rooms; //index 0 = LR, index 1 = LRB, index 2 = LRT, index 3 = LRTB

        public LayerMask room;

        private int downCounter;

        private int direction;
        public float moveAmount;

        private float timeBetweenRoom;
        public float startTimeBetweenRoom = 0.25f;

        public float minX;
        public float maxX;
        public float minZ;
        public bool stopGeneration;

        public GameObject player;

        private void Start()
        {
        int randStartingPos = Random.Range(0, startingPos.Length); // Randomise starting point
        transform.position = startingPos[randStartingPos].position; // setting the starting position to the random point
            player.transform.position =  new Vector3(startingPos[randStartingPos].position.x, (startingPos[randStartingPos].position.y + 3));
        Instantiate(rooms[0], transform.position, Quaternion.identity); // Instantiate  room 0

        direction = Random.Range(1, 6); // randomise the direction
        }

        private void Update()
        {
            if (timeBetweenRoom <= 0 && stopGeneration == false) // spawning more rooms
            {
                Move();
                timeBetweenRoom = startTimeBetweenRoom;
            }
            else
            {
                timeBetweenRoom -= Time.deltaTime;
            }
        }

        private void Move()
        {
            if (direction == 1 || direction == 2) // move Right
            {
                if (transform.position.x < maxX)
                {
                    downCounter = 0;
                    Vector3 newPos = new Vector3(transform.position.x + moveAmount, transform.position.y, transform.position.z);
                    transform.position = newPos;

                    int rand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);

                    direction = Random.Range(1, 6);
                    if (direction == 3)
                    {
                        direction = 2;
                    }
                    else if (direction == 4)
                    {
                        direction = 5;
                    }
                }
                else
                {
                    direction = 5;
                }
            
            }
            else if (direction == 3 || direction == 4) // move Left
            {
                if (transform.position.x > minX)
                {
                    downCounter = 0;
                    Vector3 newPos = new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z);
                    transform.position = newPos;
                
                    int rand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);

                    direction = Random.Range(3, 6);
                
                }
                else
                {
                    direction = 5;
                }
            
            }
            else if (direction == 5) // move Down
            {
                    downCounter++;
                if (transform.position.z > minZ)
                {
                    Collider[] roomDetection = Physics.OverlapSphere(transform.position, 1, room);
                    foreach (var collider in roomDetection)
                    {
                        if (collider.GetComponent<RoomType>().type != 1 &&
                            collider.GetComponent<RoomType>().type != 3)
                        {
                            if(downCounter >= 2)
                            {
                                collider.GetComponent<RoomType>().RoomDestruction();
                                Instantiate(rooms[3], transform.position, Quaternion.identity);
                            }
                            else
                            {
                                collider.GetComponent<RoomType>().RoomDestruction();
                                int randBottomRoom = Random.Range(1, 4);
                                if (randBottomRoom == 2)
                                {
                                    randBottomRoom = 1;
                                }

                                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                            }
                            
                        }
                    }
                
                
                    Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveAmount);
                    transform.position = newPos;

                    int rand = Random.Range(2, 4);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);
                
                    direction = Random.Range(1, 6);
                }
                else
                {
                    stopGeneration = true;
                }
            
            }

        
        
        }
    }
}

