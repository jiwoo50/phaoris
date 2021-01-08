﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject barrierObject;

    Rigidbody2D rigidBody2d;
    SpriteRenderer spriteRenderer;
    PlayerBarrierAttack playerBarrierAttack;
    Barrier barrier;

    bool isUnBeatTime = false;
    bool isBarrier = false;
    
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerBarrierAttack = GetComponent<PlayerBarrierAttack>();
        barrier = barrierObject.GetComponent<Barrier>();
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
        if (collision.gameObject.tag == "enemy" && !collision.isTrigger && !isUnBeatTime&& !IsBarrierOn())
        {
            PatrolEnemy patrolEnemy = collision.GetComponent<PatrolEnemy>();
            HealthControl playerHealth = this.GetComponent<HealthControl>();
            Vector2 attackedVelocity = Vector2.zero;
            attackedVelocity = new Vector2(5.0f * transform.localScale.x * -1.0f, 5f);
            rigidBody2d.AddForce(attackedVelocity, ForceMode2D.Impulse);
            if (!playerHealth.HealthZero())
            {
                isUnBeatTime = true;
                playerHealth.ChangeHealth(patrolEnemy.Damage());
                StartCoroutine("UnBeatTime");
            }
        }
    }
    bool IsBarrierOn()
    {
        if(barrierObject.activeSelf)
        {
            return barrier.isBarrierOn;
        }
        else
        {
           return false;
        }
    }
    
}