using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float maxHealth = 100;

    private float curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TileTakeDamage(int damage)
    {
        curHealth -= damage;

        

        if (curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
     
    }
}
