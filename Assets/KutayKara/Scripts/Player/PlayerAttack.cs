using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : Attack
{
    [SerializeField] private PlayerData playerData;
    //Targets 
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] private bool _isAttacking = false;
    
    private float attackCooldown;


    protected override void OnStart()
    {
        attackCooldown = playerData.attackCooldown;
        projectile = playerData.projectilePrefab;
    }
    
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
        RemoveTarget(target);
    }

    protected override void Projectile(GameObject target)
    {
        var obj = projectilePool.Get();
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
        //Todo:for this time they only die for one projectile. Refactor this.
        RemoveTarget(nearestTarget);
        yield return new WaitForSeconds(attackCooldown);
        _isAttacking = false;
        if (targets.Count > 0) AttackTarget();

    }

    public void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
    }
    
    
    GameObject CalculateNearestEnemy() =>targets.OrderBy(x =>
        Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    


}
