using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAtkEnemy : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;
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
        
        RaycastHit2D attackRaycast = Physics2D.Raycast(transform.position, transform.localScale * -1, distance, isLayer);
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
