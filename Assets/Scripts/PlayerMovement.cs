using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    
    private Vector2 moveInput;
    private Rigidbody2D rdbd2d;

    private void Awake()
    {
        rdbd2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Run();
        FlipSprite();
    }
    
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rdbd2d.velocity.y);
        rdbd2d.velocity = playerVelocity;
    }

    private void FlipSprite()
    {
        bool isPlayerHasHorSpeed = Mathf.Abs(rdbd2d.velocity.x) > Mathf.Epsilon;
        if (isPlayerHasHorSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rdbd2d.velocity.x), 1f);
        }
    }
}
