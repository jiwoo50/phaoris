using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAttack : MonoBehaviour
{
    public GameObject VirusPrefab;

    float currtime = 0;
    float saveDirection;
    float direction;
    bool fireOn = false;
    Rigidbody2D rigidbody2D;
    PatrolEnemy patrolEnemy;
    Animator animator;
    GameObject parent ;
    
    private void Awake()
    {
        parent = transform.parent.gameObject;
        rigidbody2D = parent.GetComponent<Rigidbody2D>();
        patrolEnemy = parent.GetComponent<PatrolEnemy>();
        animator = parent.GetComponent<Animator>();
    }
    
    IEnumerator Fire()
    {
        while (fireOn)
        {
            animator.Play("Attack");
            GameObject projectileObject = Instantiate(VirusPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
            Virus projectile = projectileObject.GetComponent<Virus>();
            projectile.Launch(direction, 300);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&fireOn==false)
        {
            patrolEnemy.setDirection = 0;
            fireOn = true;
            if (parent.transform.position.x < collision.gameObject.transform.position.x)
            {
                saveDirection = parent.transform.localScale.x;
                parent.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                direction = 1.0f;
            }
            else if (parent.transform.position.x > collision.gameObject.transform.position.x)
            {
                saveDirection = parent.transform.localScale.x;
                parent.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                direction = -1.0f;
            }
            StartCoroutine("Fire");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            patrolEnemy.setDirection = patrolEnemy.SaveDirection();
            parent.transform.localScale = new Vector3(saveDirection, 1.0f, 1.0f);
            fireOn = false;
            StartCoroutine("Fire");
        }
    }
}
