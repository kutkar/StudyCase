using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackRange;
    [SerializeField] private float radiusMultiplier;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Since plane units are 10x10 the multiplier is needed.
        Gizmos.DrawWireSphere(transform.position,attackRange.transform.localScale.x*radiusMultiplier); //Will be the attack range
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
