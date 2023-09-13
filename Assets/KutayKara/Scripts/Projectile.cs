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
        Debug.Log("Triggering but who?" + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            other.gameObject.SetActive(false);
            attacker._projectilePool.Release(this);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(projectileData.Damage);
            attacker._projectilePool.Release(this);
        }
    }

    void Boomerang()
    {
        transform.position = Vector3.Slerp(transform.position,target.position,projectileData.Speed*Time.deltaTime);
    }

    void Direct()
    {
        
    }
}
