using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class AIAgent : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public AIHealth health;
    public AIAttack aiAttack;
    public Transform target;
    public float attackRange = 5.0f;
    public float attackPlayerSpeed = 5.0f;
    [HideInInspector] public AIStateMachine StateMachine;
    [SerializeField] private AIStateId currentState; //To monitorize
    void Start()
    {
        InitializeAI();
    }

    private void Update()
    {
        StateMachine.Update();
        currentState = StateMachine.currentState;
    }

    private void InitializeAI()
    {
        health.currentHealth = health.maxHealth;
        StateMachine = new AIStateMachine(this);
        StateMachine.RegisterState(new AIAttackState());
        StateMachine.RegisterState(new AIDeathState());
        StateMachine.ChangeState(AIStateId.AttackPlayer);
        
    }
}
