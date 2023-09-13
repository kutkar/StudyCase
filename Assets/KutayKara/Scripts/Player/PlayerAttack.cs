using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : Attack
{
    //Targets 
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] private bool _isAttacking = false;
    [SerializeField] float attackCooldown = 2.0f;
    
    
    protected override void OnEnter(GameObject target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            targets.Add(target);
            AttackTarget();    
        }
        
    }
    
    protected override void OnExit(GameObject target)
    {
        targets.Remove(target);
    }

    protected override void Projectile(GameObject target)
    {
        var obj = _projectilePool.Get();
        obj.target = target.transform;
        obj.transform.rotation = Quaternion.LookRotation(target.transform.position);
    }

    private void AttackTarget()
    {
        var nearestTarget = CalculateNearestEnemy();
        if(nearestTarget == null) return;
        StartCoroutine(AttackCoroutine(nearestTarget));
    }

    IEnumerator AttackCoroutine(GameObject nearestTarget)
    {
        if(_isAttacking) yield break;
        _isAttacking = true;
        yield return new WaitForSeconds(0.5f); //First attack delay
        Projectile(nearestTarget);
        yield return new WaitForSeconds(attackCooldown);
        _isAttacking = false;
        if (targets.Count > 0) AttackTarget();

    }
    
    GameObject CalculateNearestEnemy() =>targets.OrderBy(x =>
        Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    


}
