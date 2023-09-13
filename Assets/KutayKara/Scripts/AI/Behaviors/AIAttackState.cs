using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackState : AIState
{

    public AIStateId GetId()
    {
        return AIStateId.AttackPlayer;
    }

    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.enabled = true;
        agent.navMeshAgent.speed = agent.attackPlayerSpeed;
    }

    public void Update(AIAgent agent)
    {
        agent.transform.LookAt(agent.target.position);
        if(!agent.navMeshAgent.enabled) return;
        UpdatePosition(agent);
        if (Vector3.Magnitude(agent.transform.position-agent.target.position) <= agent.attackRange)
        {
            AttackPlayer(agent);
        }
    }

    public void Exit(AIAgent agent)
    {
        
    }

    private void AttackPlayer(AIAgent agent)
    {
        if (!agent.aiAttack.isAttacking)
        {
            agent.aiAttack.isAttacking = true;
            agent.aiAttack.AttackPlayer(agent.target);
        }
    }

    private void UpdatePosition(AIAgent agent)
    {
            agent.navMeshAgent.SetDestination(agent.target.position);
    }
}
