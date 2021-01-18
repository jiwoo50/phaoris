using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSearchPlayer : MonoBehaviour
{
    public bool findPlayer=false;

    Vector3 playerPosition;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (findPlayer == false)
        {
            rigidbody2D.velocity = new Vector2(3, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            findPlayer = true;
            playerPosition = collision.gameObject.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            findPlayer = true;
            playerPosition = collision.gameObject.transform.position;
        }
    }
}
