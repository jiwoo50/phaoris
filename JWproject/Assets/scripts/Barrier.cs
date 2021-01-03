using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float currentTime = 1.0f;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime<=0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        

        Destroy(gameObject);
    }
}
