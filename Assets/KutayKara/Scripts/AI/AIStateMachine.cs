using UnityEngine;

public class AIStateMachine
{
    public AIState[] states;
    public AIAgent agent;
    public AIStateId currentState;

    public AIStateMachine(AIAgent agent) //constructor
    {
        this.agent = agent;
        var numStates = System.Enum.GetNames(typeof(AIStateId)).Length;
        states = new AIState[numStates];
    }

    public void RegisterState(AIState state) //to store pre-allocated states into the array.
    {
        var index = (int)state.GetId();
        states[index] = state;
    }

    public AIState GetState(AIStateId stateId)
    {
        var index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }

    public void ChangeState(AIStateId newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}