
using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] UIHealthBar _healthBar;
    private static readonly int Dead = Animator.StringToHash("Dead");
    public GameObject restartButton;

    protected override void OnDamage(float amount)
    {
        currentHealth -= amount;
        _healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(maxHealth);
        }
    }

    protected override void OnDeath()
    {
        GetComponentInParent<PlayerLocomotion>().enabled = false;
        GetComponentInParent<Animator>().SetTrigger(Dead);
        restartButton.SetActive(true);
    }
    
    
    
}
