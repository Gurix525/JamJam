using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _inputDirection;
    private Rigidbody _rb;
    public float speed = 5f;
    private Camera _mainCamera; 

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main; 
    }

    public void Update()
    {
        Vector3 forward = _mainCamera.transform.forward;
        Vector3 right = _mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * _inputDirection.y + right * _inputDirection.x).normalized;

        _rb.velocity = moveDirection * speed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = lookRotation;
        }
    }

    public void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
    }
}