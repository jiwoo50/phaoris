using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl: MonoBehaviour
{
    public float movePower = 1.0f;
    public float jumpPower = 1.0f;
    
    bool isJumping = false;
    bool isWalking = false;
    bool isDown = false;
    Vector3 movement;

    Rigidbody2D rigidBody2d;
    Animator animator;
    PlayerBarrierAttack playerBarrierAttack;

    private void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerBarrierAttack = gameObject.GetComponent<PlayerBarrierAttack>();
    }
    private void Update()
    {
        if (rigidBody2d.velocity.y < 0|| isDown==true)
        {
            animator.SetBool("isDown", true);
            animator.SetBool("isRunning", false);
        }
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if(isWalking)
            animator.SetBool("isRunning", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            if(isWalking)
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (isWalking)
                animator.SetBool("isRunning", true);

        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
        
        if (IsJump() && isJumping==false)
        {
            isJumping = true;
            animator.SetTrigger("isJumping");
            animator.SetBool("jumpFinish",false);
            rigidBody2d.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigidBody2d.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
    }
    bool IsJump()
    {
        return Input.GetButtonDown("Jump");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && rigidBody2d.velocity.y < 0)
        {
            animator.SetBool("jumpFinish", true);
            isJumping = false;
            isWalking = true;
        }
    }
    public void StampAndJump()
    {
        if (playerBarrierAttack.BarrierState()&&(isJumping||rigidBody2d.velocity.y<0))
        {
            rigidBody2d.velocity = new Vector2(0, rigidBody2d.velocity.y * -1.4f);
            playerBarrierAttack.BarrierOff();
            playerBarrierAttack.ChangeState(false);
        }
        
    }
}
