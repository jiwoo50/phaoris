using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float damage=1f;
    float nextMove=1.0f;
    
    Rigidbody2D rigidBody2D;
    Animator animator;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(3.0f*nextMove, rigidBody2D.velocity.y);
        Vector2 frontVector = new Vector2(rigidBody2D.position.x + nextMove * 0.4f, rigidBody2D.position.y);
        RaycastHit2D raycast = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("map"));
        transform.localScale = new Vector3(-1.0f*nextMove, 1.0f, 1.0f);
        if (raycast.collider == null)
        {
            nextMove = nextMove * (-1);
        }
    }
   
}
