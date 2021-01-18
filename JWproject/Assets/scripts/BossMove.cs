using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public GameObject meleeAttack;

    Rigidbody2D rigidbody2D;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Invoke("StartJump", 0.1f);
    }
    private void FixedUpdate()
    {
        if (rigidbody2D.velocity.x == 0)
        {
            animator.SetBool("isRun", false);
        } 
    }
    IEnumerator Jump()
    {
        Vector2 startJump = new Vector2(0, 7);
        int count = 0;
        while (count < 3)
        {
            rigidbody2D.AddForce(startJump, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        yield return null;
    }
    void StartJump()
    {
        StartCoroutine("Jump");
    }
}
