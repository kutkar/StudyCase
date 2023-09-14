using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    public float waitTime = 5.0f;

    public AIStateId GetId()
    {
        return AIStateId.Death;
    }
    
    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.enabled = false;
        agent.GetComponent<Collider>().enabled = false;
        agent.animator.SetTrigger("Dead");
        
    }

    public void Update(AIAgent agent)
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
            Exit(agent);

    }

    public void Exit(AIAgent agent)
    {
        waitTime = 5.0f;
        agent.agentPool.Release(agent);
        agent.health.currentHealth = agent.health.maxHealth;
    }
    
    
}
