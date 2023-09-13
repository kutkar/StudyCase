using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;
    private static readonly int Speed = Animator.StringToHash("Speed");


    void Update()
    {
        animator.SetFloat(Speed,Mathf.Abs(joystick.Horizontal)+Mathf.Abs(joystick.Vertical));
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed,0 , joystick.Vertical*speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(new Vector3(joystick.Horizontal, 0, joystick.Vertical)),
                rotationSpeed * Time.deltaTime);
    }
}
