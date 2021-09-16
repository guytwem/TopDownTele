using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Abilities
{
    public class Fireball : MonoBehaviour
    {
        public GameObject fireballPrefab;
        public Transform fireballSpawn;
        public float fireballSpeed = 5f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ShootFire();
            }
        }

        public void ShootFire()
        {
            GameObject fireballGameObject = Instantiate(fireballPrefab); // instantiate prefab
            Physics.IgnoreCollision(fireballGameObject.GetComponent<Collider>(), fireballSpawn.parent.GetComponent<Collider>()); //ignore collision between player and gameObject

            fireballGameObject.transform.position = fireballSpawn.position; //where the fireball starts from

            Vector3 rotation = fireballGameObject.transform.rotation.eulerAngles; // fireball starting rotation
            
            fireballGameObject.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            
            fireballGameObject.GetComponent<Rigidbody>().AddForce(fireballSpawn.forward * fireballSpeed, ForceMode.Force); // adds force propelling forward

            StartCoroutine(DestroyObjectAfterTime(fireballGameObject, 5)); //destroy the fireball after 5 seconds
        }

        private IEnumerator DestroyObjectAfterTime(GameObject fireballGameObject, float delay) // destroy gameObject after a delay
        {
            yield return new WaitForSeconds(delay);
            
            Destroy(fireballGameObject);
        }
    } 
}

