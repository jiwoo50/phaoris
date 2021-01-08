using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float damage = 1.0f;
    public GameObject player;
    public bool isBarrierOn = false;
    MoveControl moveControl;
    PlayerBarrierAttack playerBarrierAttack;
    BarrierJump barrierJump;
    private void Awake()
    {
        moveControl = player.GetComponent<MoveControl>();
        playerBarrierAttack = player.GetComponent<PlayerBarrierAttack>();
        barrierJump = player.GetComponent<BarrierJump>();
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
            moveControl.StampAndJump();
            JumpTime();
        }
    }
}
