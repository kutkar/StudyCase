
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] UIHealthBar _healthBar;

    protected override void OnDamage(float amount)
    {
        currentHealth -= amount;
        _healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

}