using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    private Vector3 direction;

    public float speed = 10;
    public float jumpForce = 10;
    public float gravity = -50;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool secondJump = true;

    public Animator animator;
    public Transform model;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerManager.gameOver == true)
        {
            animator.SetTrigger("isDead");
            this.enabled = false;
        }

        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        animator.SetFloat("speed", Mathf.Abs(hInput));
        bool isGround = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("ground", isGround);
               
        if(isGround)
        {
            direction.y = -1;
            secondJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("fireBallAttack");
            }
        }

        else 
        {
            direction.y += gravity * Time.deltaTime;
            if (secondJump && Input.GetButtonDown("Jump"))
            {
                doubleJump();
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireBallAttack"))
        {
            return;
        }

        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
        controller.Move(direction * Time.deltaTime);

        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void doubleJump()
    {
        direction.y = jumpForce;
        secondJump = false;
        animator.SetTrigger("doubleJump");
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}