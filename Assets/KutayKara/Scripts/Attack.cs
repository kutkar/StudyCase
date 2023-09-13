using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject attackRange;
    [SerializeField] private float radiusMultiplier;
    [SerializeField] private SphereCollider collider;
    
    
    public Projectile projectile;
    public ObjectPool<Projectile> _projectilePool;

    //Debugging
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Since plane units are 10x10 the multiplier is needed.
    //    Gizmos.DrawWireSphere(transform.position,attackRange.transform.localScale.x*radiusMultiplier); //Will be the attack range
    //    
    //}


    private void Start()
    {
        if (collider)
        {
            Debug.Log("Collider Scale: "+attackRange.transform.localScale.x);
            collider.radius = attackRange.transform.localScale.x * radiusMultiplier;
        }
        
        var poolPrefab = projectile;
        _projectilePool = new ObjectPool<Projectile>(() =>
            {
                return Instantiate(poolPrefab,transform.position,Quaternion.identity);
            },
            _type =>
            {
                _type.attacker = this;
                _type.transform.position = transform.position;
                _type.gameObject.SetActive(true);
            },
            _type =>
            {
                _type.gameObject.SetActive(false);
            },_type =>
            {
                Destroy(_type.gameObject);
            },false,10);
    }


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

    protected virtual void Projectile(GameObject target)
    {
        
    }

    
}
