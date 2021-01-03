using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAtkEnemy : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;
    float nextMove = 1.0f;
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;
    public GameObject virus;
    public Transform pos;
    // Start is called before the first frame update
    public float cooltime;
    private float currenttime;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(3.0f * nextMove, rigidBody2D.velocity.y);
        Vector2 frontVector = new Vector2(rigidBody2D.position.x + nextMove * 0.4f, rigidBody2D.position.y);
        RaycastHit2D raycast = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("map"));
        transform.localScale = new Vector3(-1.0f * nextMove, 1.0f, 1.0f);
        if (raycast.collider == null)
        {
            nextMove = nextMove * (-1);
        }
        
        RaycastHit2D attackRaycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (attackRaycast.collider != null)
        {
            if (Vector2.Distance(transform.position, attackRaycast.collider.transform.position) < atkDistance)
            {
                if (currenttime <= 0)
                {
                    GameObject viruscopy = Instantiate(virus, pos.position, transform.rotation);
                    currenttime = cooltime;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, attackRaycast.collider.transform.position, Time.deltaTime * speed);

                }
                currenttime -= Time.deltaTime;
            }
        }
    }
}
