using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierJump : MonoBehaviour
{
    PlayerBarrierAttack playerBarrierAttack;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        playerBarrierAttack = this.GetComponent<PlayerBarrierAttack>();
    }
    public void StampAndJump()
    {
            Vector2 jumpVelocity = new Vector2(0, 5.0f);
            rigidbody2D.AddForce(jumpVelocity*10f, ForceMode2D.Impulse);
            playerBarrierAttack.BarrierOff();
        
    }
}
