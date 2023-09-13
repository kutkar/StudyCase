using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    protected override void OnDamage(float amount)
    {
        
    }

    protected override void OnDeath()
    {
        //todo: return to the pool;
    }

    
}
