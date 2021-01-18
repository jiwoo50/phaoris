using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float damage = 1.0f;
    public GameObject player;
    public bool isBarrierOn = false;

    Player playerScript;
    PlayerBarrierAttack playerBarrierAttack;
    private void Awake()
    {
        playerScript = player.GetComponent<Player>();
        playerBarrierAttack = player.GetComponent<PlayerBarrierAttack>();
    }
    void OnDisable()
    {
        isBarrierOn = false;
    }
    void JumpTime()
    {
        isBarrierOn = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy"&&playerBarrierAttack.BarrierState()&&!isBarrierOn)
        {
            playerScript.StampAndJump();
            JumpTime();
        }
    }
}
