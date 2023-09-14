using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody rigidbody;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private float speed;
    private float rotationSpeed;

    private void Start()
    {
        if (playerData == null)
            throw new Exception("PlayerData is null");
        else
        {
            speed = playerData.speed;
            rotationSpeed = playerData.rotationSpeed;
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed,0 , joystick.Vertical*speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
            //transform.rotation = Quaternion.Slerp(transform.rotation,
            //    Quaternion.LookRotation(new Vector3(joystick.Horizontal, 0, joystick.Vertical)),
            //   rotationSpeed * Time.deltaTime);
        animator.SetFloat(Speed,Mathf.Abs(joystick.Horizontal)+Mathf.Abs(joystick.Vertical));
    }
}
