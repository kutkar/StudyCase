
using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] UIHealthBar _healthBar;

    protected override void OnDamage(float amount)
    {
        currentHealth -= amount;
        _healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Dead");
        }
    }
}
