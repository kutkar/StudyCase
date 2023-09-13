using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    protected override void OnDamage(float amount)
    {
        currentHealth -= amount;
    }

    protected override void OnDeath()
    {
        agent.StateMachine.ChangeState(AIStateId.Death);
    }

    
}
