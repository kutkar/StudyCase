using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Transform target;
    public Attack attacker;
    [SerializeField] private ProjectileData projectileData;
    private float lifeTime = 0.0f;
    public Vector3 Target;

    private void FixedUpdate()
    {
        switch (projectileData.projectileType)
        {
            //switch-case is used to determine the projectile type.
            case ProjectileData.ProjectileType.Boomerang:
                Boomerang();
                break;
            case ProjectileData.ProjectileType.Direct:
                Direct();
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<AIHealth>().TakeDamage(projectileData.Damage);
            attacker.projectilePool.Release(this);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(projectileData.Damage);
            attacker.projectilePool.Release(this);
        }
    }

    void Boomerang()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, projectileData.Speed * Time.deltaTime);
    }

    void Direct()
    {
        
        //this.transform.position = Vector3.MoveTowards(transform.position, Target-transform.position, projectileData.Speed * Time.deltaTime);
        this.transform.position = transform.position+(Target).normalized * (projectileData.Speed * Time.deltaTime);
        lifeTime+= Time.deltaTime;
        if (lifeTime >= projectileData.TimeToLive)
        {
            lifeTime = 0.0f;
            attacker.projectilePool.Release(this);
        }
    }
}
