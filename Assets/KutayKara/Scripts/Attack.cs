using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 10.0f;
    public float attackCoolDown = 3.0f;
    
    
    [SerializeField] private GameObject attackRange;
    [SerializeField] private float radiusMultiplier;
    [SerializeField] private SphereCollider collider;
    
    
    //Debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Since plane units are 10x10 the multiplier is needed.
        Gizmos.DrawWireSphere(transform.position,attackRange.transform.localScale.x*radiusMultiplier); //Will be the attack range
        collider.radius = attackRange.transform.localScale.x * radiusMultiplier;
    }
    
    //Collusion detection layers set in inspector. 
    private void OnTriggerEnter(Collider other)
    {
          OnEnter(other.gameObject);
    }


    private void OnTriggerExit(Collider other)
    {
           OnExit(other.gameObject);
    }

    protected virtual void OnEnter(GameObject target)
    {
        
    }

    protected virtual void OnExit(GameObject target)
    {
        
    }

    protected virtual void Projectile(GameObject projectile, GameObject target)
    {
        
    }

    
}
