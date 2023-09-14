using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class AIAgent : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public AIHealth health;
    public AIAttack aiAttack;
    [HideInInspector]public Transform target;
    public float attackRange = 5.0f;
    public float attackPlayerSpeed = 5.0f;
    public int scoreContribution = 1;
    [HideInInspector] public AIStateMachine StateMachine;
    [SerializeField] private AIStateId currentState; //To monitorize
    public ObjectPool<AIAgent> agentPool;
    void Start()
    {
        InitializeAI();
    }

    private void Update()
    {
        StateMachine.Update();
        currentState = StateMachine.currentState;
    }

    public void InitializeAI()
    {
        StateMachine = new AIStateMachine(this);
        StateMachine.RegisterState(new AIAttackState());
        StateMachine.RegisterState(new AIDeathState());
        StateMachine.ChangeState(AIStateId.AttackPlayer);
    }

    private void OnEnable()
    {
        if(StateMachine!=null)
            StateMachine.ChangeState(AIStateId.AttackPlayer);
    }
}
