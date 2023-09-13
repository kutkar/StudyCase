using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ProjectileData : ScriptableObject
{
    public enum ProjectileType 
    {
        Boomerang,
        Direct
    }
    public ProjectileType projectileType;
    public float Speed;
    public float Damage;
    public float TimeToLive;
}
