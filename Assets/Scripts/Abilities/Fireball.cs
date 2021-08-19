using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Abilities
{
    public class Fireball : UseAbility
    {
        public GameObject fireballPrefab;
        public Transform fireballSpawn;
        private float fireballSpeed = 5;
        
        public override void TriggerAbility()
        {
            GameObject fireballGameObject = Instantiate(fireballPrefab);
            Physics.IgnoreCollision(fireballGameObject.GetComponent<Collider>(), fireballSpawn.parent.GetComponent<Collider>());

            fireballGameObject.transform.position = fireballSpawn.position;

            Vector3 rotation = fireballGameObject.transform.rotation.eulerAngles;
            
            fireballGameObject.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            
            fireballGameObject.GetComponent<Rigidbody>().AddForce(fireballSpawn.forward * fireballSpeed, ForceMode.Force);

            StartCoroutine(DestroyObjectAfterTime(fireballGameObject, 5));
        }

        private IEnumerator DestroyObjectAfterTime(GameObject fireballGameObject, float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Destroy(fireballGameObject);
        }
    } 
}

