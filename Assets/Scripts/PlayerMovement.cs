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
    public float baseSpeed = 5f;
    public float speed;
    private Camera _mainCamera;
    private Inventory _inventory;
    public float speedPercentsPerItem;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        speed = baseSpeed;
        _inventory = GameObject.FindObjectOfType<Inventory>();
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

    public void UpdateSpeed()
    {
        speed = baseSpeed * (1-(_inventory.GetStackLen() * speedPercentsPerItem));
    }
}