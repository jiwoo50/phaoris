using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float rightMax = 4.0f;
    public float leftMax = -4.0f;
    public float setDirection = 3.0f;

    float damage = 1.0f;
    float saveDirection;
    Vector3 moveVelocity=Vector3.right;
    Vector3 pos;
    private void Awake()
    {
        pos = transform.position;
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        saveDirection = setDirection;
    }

    void FixedUpdate()
    {
        transform.position += moveVelocity * setDirection * Time.deltaTime;

        if (transform.position.x > pos.x + rightMax)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        else if (transform.position.x < pos.x + leftMax)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            moveVelocity = Vector3.right;
        }
    }

    public float Damage()
    {
        return damage;
    }

    public float SaveDirection()
    {
        return saveDirection;
    }
}
