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
    public void ChangeHealth(float damage)
    {
        health-=damage*infectionRate;
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
    
}
