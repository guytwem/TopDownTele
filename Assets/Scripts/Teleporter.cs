using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Teleporter
{
    public class Teleporter : MonoBehaviour
    {
        public GameObject teleporterOne;
        public GameObject teleporterTwo;
        public GameObject player;


        private void OnTriggerEnter(Collider other)
        {
            if (gameObject.tag == "TeleporterOne" && other.gameObject.tag == "Player")
            {
                Debug.Log("Entered Teleporter One");
                player.transform.position = new Vector3(teleporterTwo.transform.position.x ,
                    teleporterTwo.transform.position.y, (teleporterTwo.transform.position.z + 2));
            }
            if (gameObject.tag == "TeleporterTwo" && other.gameObject.tag == "Player")
            {
                Debug.Log("Entered Teleporter Two");
                player.transform.position = new Vector3(teleporterOne.transform.position.x,
                    teleporterOne.transform.position.y, (teleporterOne.transform.position.z + 2));
            }
        }
    }
}

