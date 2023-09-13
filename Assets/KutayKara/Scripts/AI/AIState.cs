public enum AIStateId
{
    Death,
    Idle,
    AttackPlayer
}

public interface AIState
{
    AIStateId GetId();
    void Enter(AIAgent agent);
    void Update(AIAgent agent);
    void Exit(AIAgent agent);
}