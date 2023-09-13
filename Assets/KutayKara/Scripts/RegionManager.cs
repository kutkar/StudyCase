using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RegionManager : MonoBehaviour
{
    public ObjectPool<AIAgent> agentPool;
    public AIAgent agent;
    public GameObject Player;
    [SerializeField] private int amountOfEnemy = 15;
    [SerializeField] private Transform min;
    [SerializeField] private Transform max;
    private void Start()
    {
        var poolPrefab = agent;
        agentPool = new ObjectPool<AIAgent>(()=>
        {
            return Instantiate(poolPrefab,transform.position,Quaternion.identity);
        },
            _type =>
            {
                _type.target = Player.transform;
                _type.agentPool = agentPool;
                _type.transform.position = GetProperLocation();
                _type.GetComponentInChildren<AIAttack>().targetForEnemy = Player;
                _type.GetComponent<Collider>().enabled = true;
                _type.gameObject.SetActive(true);
            },
_type =>
            {
                _type.gameObject.SetActive(false);
            },_type =>
            {
                Destroy(_type.gameObject);
            },false,amountOfEnemy);
            
        
    }

    public void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (agentPool.CountActive >= amountOfEnemy) return;
        agentPool.Get();
    }

    private Vector3 GetProperLocation()
    {
        var loc = new Vector3(UnityEngine.Random.Range(min.position.x,max.position.x),0,UnityEngine.Random.Range(min.position.z,max.position.z));
        if(Vector3.Distance(loc,Player.transform.position)<10) return GetProperLocation();
        return loc;
    }
    
    
}
