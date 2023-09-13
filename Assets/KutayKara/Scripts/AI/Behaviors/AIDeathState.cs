using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    

    public AIStateId GetId()
    {
        return AIStateId.Death;
    }

    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.enabled = false;
        agent.animator.SetTrigger("Death");
    }

    public void Update(AIAgent agent)
    {
        

    }

    public void Exit(AIAgent agent)
    {
        //Todo: return pool
    }
    
    
}
