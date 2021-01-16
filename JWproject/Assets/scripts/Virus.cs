using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float currentTime = 1.5f;
    float damage = 1.0f;
    void Awake()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Launch(float direction, float force)
    {
        Vector2 directionVector = new Vector2(direction, 0);
        rigidbody2d.AddForce(directionVector * force, ForceMode2D.Force);
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if (currentTime<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            HealthControl healthControl = collision.gameObject.GetComponent<HealthControl>();
            Destroy(this.gameObject);
            healthControl.Damage(damage);
            
        }
        else if (collision.gameObject.tag == "barrier" || collision.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }
    }
}
