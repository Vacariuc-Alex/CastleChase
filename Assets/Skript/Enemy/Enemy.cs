using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float atackRange = 2;
    public int speed = 5;
    public int health;
    public int maxHealth = 100;

    public Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
;    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerManager.gameOver == true)
        {
            animator.enabled = false;
            this.enabled = false;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance < chaseRange)
            {
                currentState = "ChaseState";
            }
        }
        else if (currentState == "ChaseState")
        {
            //Play Run Animation
            animator.SetTrigger("chase");
            animator.SetBool("isAtacking", false);

            if(distance < atackRange)
            {
                currentState = "AtackState";
            }

            //Move towards the player
            if (target.position.x > transform.position.x)
            {
                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }

            else
            {
                //Move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        else if (currentState == "AtackState")
        {
            animator.SetBool("isAtacking", true);

            if (distance > atackRange)
            {
                currentState = "ChaseState";
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState = "ChaseState";
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play Die Animation
        animator.SetTrigger("isDead");
        //Disable scrip and colider
        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
    }
}
