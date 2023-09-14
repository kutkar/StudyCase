using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    public AIAgent agent;
    
    protected override void OnStart()
    {
        currentHealth = maxHealth;
        agent = GetComponent<AIAgent>();
    }
    protected override void OnDamage(float amount)
    {
        currentHealth -= amount;
    }

    protected override void OnDeath()
    {
        agent.target.GetComponentInChildren<PlayerHealth>().AddScore(agent.scoreContribution);
        agent.StateMachine.ChangeState(AIStateId.Death);
    }

    
}
