using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Image healthBar;
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth/ maxHealth;
    }

    public void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);
    }
    
   
    
}
