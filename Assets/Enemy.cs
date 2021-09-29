using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animEnemy;

    public float speed = 3f;
    public float rotationSpeed = 10f;

    public float checkRadius = 5f;
    public LayerMask playerMask;
    private bool isPlayer;

    public GameObject player;
    public Transform playerTrans;

    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    private void Update()
    {
        isPlayer = Physics.CheckSphere(gameObject.transform.position, checkRadius, playerMask);

        if(isPlayer == true)
        {
            Vector3 targetDirection = playerTrans.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            
            
            
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animEnemy.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy Died");
        animEnemy.SetBool("isDead", true);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
