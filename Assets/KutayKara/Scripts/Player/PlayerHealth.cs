
using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] PlayerData playerData;
    private static readonly int Dead = Animator.StringToHash("Dead");

    public int gold;
    public int score;
    
    //This and coin pickup can be stay here for a while.
    public GameObject restartButton;
    [SerializeField] UIHealthBar _healthBar;
    [SerializeField] GoldAndScoreUI _goldAndScoreUI;
        
    protected override void OnStart()
    {
        currentHealth = playerData.maxHealth;
    }
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
        playerData.score = score;
        playerData.amountOfGold = gold;
    }


    public void AddGold(int goldContribution)
    {
        gold += goldContribution;
        _goldAndScoreUI.UpdateGoldText(gold);
    }
    public void AddScore(int scoreContribution)
    {
        score += scoreContribution;
        _goldAndScoreUI.UpdateScoreText(score);
    }
    
}
