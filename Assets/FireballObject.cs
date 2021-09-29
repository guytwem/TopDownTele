using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballObject : MonoBehaviour
{

    
    public int fireballDamage = 60;

   

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(fireballDamage);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Tile")
        {
            other.GetComponent<Tile>().TileTakeDamage(fireballDamage);
            Destroy(gameObject);
        }
        
    }
}
