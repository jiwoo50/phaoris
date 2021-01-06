using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;
    float nextMove=1.0f;
    Vector2 attackedVelocity = Vector2.zero;
    bool barrierTrigger = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //if(!barrierTrigger)
        rigidBody2D.velocity = new Vector2(3.0f*nextMove, rigidBody2D.velocity.y); 
        
        Vector2 frontVector = new Vector2(rigidBody2D.position.x + nextMove * 0.4f, rigidBody2D.position.y);
        RaycastHit2D raycast = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("map"));
        transform.localScale = new Vector3(-1.0f*nextMove, 1.0f, 1.0f);
        if (raycast.collider == null)
        {
            nextMove = nextMove * (-1);
        }
        /*
        if (barrierTrigger)
        {
            Debug.Log("barrier");
            nextMove = nextMove * (-1);
            rigidBody2D.AddForce(attackedVelocity, ForceMode2D.Impulse);
            barrierTrigger = false;
        }*/
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveControl player = collision.gameObject.GetComponent<MoveControl>();
        if (player != null)
        {
            //Debug.Log("enemyhurrtt"+i);
            nextMove = nextMove * (-1);
            player.ChangeHealth(-1);
           // i++;
        }
        if (collision.gameObject.tag == "barrier" )
        {
           
           
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                attackedVelocity = new Vector2(-50f, 0f);
            }
            else
                attackedVelocity = new Vector2(50f, 0f);
            // rigidBody2D.AddForce(attackedVelocity, ForceMode2D.Impulse);
            rigidBody2D.AddRelativeForce(attackedVelocity, ForceMode2D.Impulse);
            //barrierTrigger = true;

        }
    }


}
