using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public AIAgent agent;
    public float maxHealth;
    public float currentHealth;
    public float lowHealth = 20.0f;
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<AIAgent>();
    }

    public void TakeDamage(float amount)
    {
        OnDamage(amount);
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        OnDeath();
    }

    protected virtual void OnStart()
    {
        //SFX VFX
    }

    protected virtual void OnDeath()
    {
        //SFX VFX
    }

    protected virtual void OnHeal(float amount)
    {
        
    }
    
    protected virtual void OnDamage(float amount)
    {
        //SFX VFX
    }
}
