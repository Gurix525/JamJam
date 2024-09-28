using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody _rb;
    public float Speed = 5f;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _rb.velocity = new Vector3(_direction.x, 0, _direction.y ) * Speed;

        if (_direction != Vector2.zero)
        {
            Vector3 target = new Vector3(_direction.x * 90, 0, _direction.y * 90);
            Quaternion lookRotation = Quaternion.LookRotation(target);
            gameObject.transform.rotation = lookRotation;
        }
    }

    public void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();
    }
}
