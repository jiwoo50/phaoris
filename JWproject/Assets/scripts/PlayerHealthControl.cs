using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public float maxHealth = 3f;
    float health = 3f;
    public void ChangeHealth(float damage)
    {
        health-=damage;
    }
    public bool HealthZero()
    {
        if (health <= 0)
            return true;
        return false;
    }
    
}
