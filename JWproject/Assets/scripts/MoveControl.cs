using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public int maxHealth = 3;
    public float movePower = 1.0f;
    public float jumpPower = 1.0f;
    public float timeInvincible = 2.0f;
    Rigidbody2D rigidBody2d;
    Animator animator;
    public GameObject barrierprefab;
    Vector3 movement;
    bool isJumping = false;
    bool isWalking = false;
    bool isDown = false;
    bool isInvincible;
    float invincibleTimer;
    int health = 3;
   
    private void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        health = maxHealth;
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
        if (Input.GetButtonDown("Jump")&&isJumping==false)
        {
            isJumping = true;
            animator.SetTrigger("isJumping");
            animator.SetBool("jumpFinish",false);
            rigidBody2d.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigidBody2d.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
            animator.SetBool("isHurt", false);
        }
    }
    void Attack()
    {
        GameObject projectileObject = Instantiate(barrierprefab, rigidBody2d.position + Vector2.up * 0.5f, Quaternion.identity);

       Barrier barrier= projectileObject.GetComponent<Barrier>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && rigidBody2d.velocity.y < 0)
        {
            animator.SetBool("jumpFinish", true);
        }
        isJumping = false;
        isWalking = true;
        if (collision.gameObject.tag == "enemy" && !collision.isTrigger && !(rigidBody2d.velocity.y < -10f))
        {
            Vector2 attackedVelocity = Vector2.zero;
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                attackedVelocity = new Vector2(-5f, 0f);
            }
            else
                attackedVelocity = new Vector2(5f, 0f);
            rigidBody2d.AddForce(attackedVelocity, ForceMode2D.Impulse);
            health--;
      
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isWalking = false;
        isDown = true;
    }
    public void ChangeHealth(int amount)
    {

        if (amount < 0)
        {
            animator.SetTrigger("hurt");
            animator.SetBool("isHurt",true);
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

            
        }

        health -= amount;
        Debug.Log(health);
    }

}
