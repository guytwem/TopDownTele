using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public float attackRate = 2f;

    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attacking();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attacking()
    {
        anim.SetTrigger("Attack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("we Hit " + enemy.name);
            if(enemy.tag == "Enemy")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            
            if(enemy.tag == "Tile")
            {
                enemy.GetComponent<Tile>().TileTakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
