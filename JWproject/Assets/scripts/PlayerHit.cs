using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    Rigidbody2D rigidBody2d;
    SpriteRenderer spriteRenderer;
    bool isUnBeatTime = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    IEnumerator UnBeatTime()
    {
        int currtime = 0;
        while (currtime < 10)
        {
            this.gameObject.layer = 11;
            if (currtime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);
            currtime++;
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);
        isUnBeatTime = false;
        this.gameObject.layer = 9;
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && !collision.isTrigger && !(rigidBody2d.velocity.y < -10f)&&!isUnBeatTime )
        {
            PatrolEnemy enemy = collision.gameObject.GetComponent<PatrolEnemy>();
            PlayerHealthControl playerHealth = this.GetComponent<PlayerHealthControl>();
            Vector2 attackedVelocity = Vector2.zero;
            attackedVelocity = new Vector2(5.0f * transform.localScale.x * -1.0f, 5f);
            rigidBody2d.AddForce(attackedVelocity, ForceMode2D.Impulse);
            if (!playerHealth.HealthZero())
            {
                isUnBeatTime = true;
                playerHealth.ChangeHealth(enemy.damage);
                StartCoroutine("UnBeatTime");
            }
        }
    }
    
}
