using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TopDown.Abilities;
using TopDown.Teleporter;
using UnityEngine.Serialization;

namespace TopDown.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public Camera cam;
        public NavMeshAgent agent;

        private Teleporter.Teleporter _teleporter;
        
        public GameObject fireballPrefab;
        public Transform spawnPos;
        public Transform swordPos;

        [FormerlySerializedAs("s_SelectAbility")] public SelectAbility sSelectAbility;
        
        [SerializeField] private List<int> characterAbilities = new List<int>();
        
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;
               if(Physics.Raycast(ray, out hit))
               {
                   Debug.Log(hit);
                   agent.SetDestination((hit.point));
               }
               
                
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Fireball();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Thrust();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                sSelectAbility.charAbilities[characterAbilities[2]].TriggerAbility();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                sSelectAbility.charAbilities[characterAbilities[3]].TriggerAbility();
            }

            

        }
        private void Fireball()
        {
            GameObject fireballGameObject = Instantiate(fireballPrefab);
            Physics.IgnoreCollision(fireballGameObject.GetComponent<Collider>(), spawnPos.parent.GetComponent<Collider>());

            fireballGameObject.transform.position = spawnPos.position;

            Vector3 rotation = fireballGameObject.transform.rotation.eulerAngles;
            
            fireballGameObject.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

            float fireballSpeed = 15;
            fireballGameObject.GetComponent<Rigidbody>().AddForce(spawnPos.forward * fireballSpeed, ForceMode.Impulse);

            StartCoroutine(DestroyObjectAfterTime(fireballGameObject, 5));
        }

        private void Thrust()
        {
            swordPos.transform.localPosition = Vector3.Lerp(spawnPos.localPosition, new Vector3(0, 0, 2), 0.1f);
        }
        
        private IEnumerator DestroyObjectAfterTime(GameObject fireballGameObject, float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Destroy(fireballGameObject);
        }

        /*public void Interact()
        {
            RaycastHit hit;
            if(Physics.SphereCast(gameObject.transform.position,15f,gameObject.transform.forward,out hit, 20f,  layerMask:3))
            {
                Debug.Log(hit);
                if (hit.collider.CompareTag("TeleporterOne"))
                {
                    _teleporter.tpOne = true;
                    _teleporter.Teleport(gameObject.transform.position);
                    _teleporter.tpOne = false;
                }
                if (hit.collider.CompareTag("TeleporterTwo"))
                {
                    _teleporter.tpTwo = true;
                    _teleporter.Teleport(gameObject.transform.position);
                    _teleporter.tpTwo = false;
                }
            }
            
        }*/
        
    }
}

    


