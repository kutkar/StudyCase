using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AIAttack : Attack
{
    public bool isAttacking = false;
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    public GameObject targetForEnemy;
    public void AttackPlayer(Transform _target)
    {
        StartCoroutine(AttackPlayerAnimation(_target));
    }

    public void Throw()
    {
        Projectile(targetForEnemy);
    }
    protected override void Projectile(GameObject target)
    {
        var obj = projectilePool.Get();
        obj.target = target.transform;
        obj.transform.rotation = this.transform.rotation;
        obj.Target = target.transform.position - obj.transform.position;
    }

    private IEnumerator AttackPlayerAnimation(Transform target)
    {
        navMeshAgent.enabled = false;
        animator.SetTrigger(Attack1);
        yield return new WaitForSeconds(0.5f); //To be sure animation is started to play
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.85f)
            yield return null;
        navMeshAgent.enabled = true;
        isAttacking = false; //best way is to create a scriptable object but for now this is enough.
    }
    
    
}
