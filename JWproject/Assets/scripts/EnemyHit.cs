using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject[] items;
    public float[] percentage;

    bool isTrigger = false;

    Animator animator;
    SpriteRenderer spriteRenderer;
    PatrolEnemy patrolEnemy;
    HealthControl healthControl;
    Rigidbody2D rigidbody2D;

    void Awake()
    {
        healthControl = GetComponent<HealthControl>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        patrolEnemy = gameObject.GetComponent<PatrolEnemy>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    IEnumerator Hurt()
    {
        isTrigger = true;
        animator.SetBool("isHurt", true);
        patrolEnemy.setDirection=0;
        Knockback();
        yield return new WaitForSeconds(0.21f);
        animator.SetBool("isHurt", false);
        if (healthControl.HealthZero())
        {
            animator.SetBool("isDie", true);
            yield return new WaitForSeconds(0.5f);
            GameObject projectileObject = Instantiate(items[(int)ChooseItem()], rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
            Destroy(this.gameObject);
        }
        patrolEnemy.setDirection = patrolEnemy.SaveDirection() ;
        isTrigger = false;
        yield return null;
    }
    void Knockback()
    {
        Vector2 knockBackVector = new Vector2(4, 0);
        rigidbody2D.AddForce(knockBackVector*gameObject.transform.localScale.x, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barrier"&&!isTrigger)
        {
            Barrier barrieDamage = collision.gameObject.GetComponent<Barrier>();
            healthControl.Damage(barrieDamage.damage);
            StartCoroutine("Hurt");
        }
    }
    float ChooseItem()
    {
        float total = 0;
        foreach (float elem in percentage)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < percentage.Length; i++)
        {
            if (randomPoint < percentage[i])
            {
                return i;
            }
            else
            {
                randomPoint -= percentage[i];
            }
        }
        return percentage.Length - 1;
    }
}
