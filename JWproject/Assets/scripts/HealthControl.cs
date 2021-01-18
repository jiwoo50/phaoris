using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    public float maxHealth = 3f;
    public float maxInfectionRate = 1f;
    float health;
    float infectionRate;
    private void Awake()
    {
        health = maxHealth;
        infectionRate = maxInfectionRate;
    }
    public void Damage(float damage)
    {
        health=Mathf.Clamp(health - damage*infectionRate,0,maxHealth);
    }
    public bool HealthZero()
    {
        if (health <= 0)
        {
            Destroy(this);
            return true;
        }
        return false;
    }
    public void Recovery(float recovery)
    {
        health = Mathf.Clamp(recovery, 0, maxHealth);
    }
    public float NowHealth()
    {
        return health;
    }
    
}
