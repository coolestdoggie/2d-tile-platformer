using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    private Vector2 moveInput;
    private Rigidbody2D rdbd2d;

    private void Awake()
    {
        rdbd2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed * Time.deltaTime, rdbd2d.velocity.y);
        rdbd2d.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
