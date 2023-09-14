using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerData : ScriptableObject
{
    public float maxHealth = 100f;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public int amountOfGold = 0;
    public int score = 0;
    
    public float attackCooldown = 1.2f;
    public Projectile projectilePrefab; 
    
}
