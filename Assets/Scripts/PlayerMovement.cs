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
    public float maxSpeed = 15f;
    public float acceleration = 1f;
    public float speed;
    private Camera _mainCamera;
    private Inventory _inventory;
    public float speedPercentsPerItem;

    private Animator _animator;
    private bool _holdingItem;
    private int inventoryCount = 0;

    public float transitionDuration = 1f;
    private float currentSpeed = 0f;

    private float speedModifier = 1f;
    

    

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        speed = baseSpeed;
        _inventory = GameObject.FindObjectOfType<Inventory>();
        _animator = GetComponentInChildren<Animator>();

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


        if (moveDirection.magnitude > 0.1f)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        _rb.velocity = moveDirection * currentSpeed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = lookRotation;
        }

        if (_animator)
        {
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        bool moving = _rb.velocity.magnitude > 1f;
        inventoryCount = _inventory.GetStackLength();
        _ = (inventoryCount != 0) ? _holdingItem = true : _holdingItem = false;

        _animator.SetFloat("velocity", _rb.velocity.magnitude);
        _animator.SetBool("holdingItems", _holdingItem);
    }


    public void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
    }

    public void UpdateSpeed()
    {
        speedModifier = 1f - (float)inventoryCount * speedPercentsPerItem;
    }
}