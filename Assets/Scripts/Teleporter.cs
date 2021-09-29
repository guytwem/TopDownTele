using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Teleporter
{
    public class Teleporter : MonoBehaviour
    {
     

        public Transform TeleportTarget;
        



        private void OnTriggerEnter(Collider other)
        {
            other.transform.position = TeleportTarget.transform.position;
        }


        
    }
}

