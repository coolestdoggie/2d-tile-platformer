using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    
    private Vector2 moveInput;
    private Rigidbody2D rdbd2d;
    private Animator myAnimator;
    private CapsuleCollider2D myCapsuleCollider2d;
    private float gravityScaleAtStart;

    private void Awake()
    {
        rdbd2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2d = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rdbd2d.gravityScale;
    }

    void FixedUpdate()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (!myCapsuleCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
                rdbd2d.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rdbd2d.velocity.y);
        rdbd2d.velocity = playerVelocity;
        
        bool isPlayerHasHorSpeed = Mathf.Abs(rdbd2d.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", isPlayerHasHorSpeed);
    }

    private void FlipSprite()
    {
        bool isPlayerHasHorSpeed = Mathf.Abs(rdbd2d.velocity.x) > Mathf.Epsilon;
        if (isPlayerHasHorSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rdbd2d.velocity.x), 1f);
        }
    }
    
    private void ClimbLadder()
    {
        if (!myCapsuleCollider2d.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            rdbd2d.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("IsClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(rdbd2d.velocity.x, moveInput.y * climbSpeed);
        rdbd2d.velocity = climbVelocity;
        rdbd2d.gravityScale = 0f;
        
        bool isPlayerHasClimbSpeed = Mathf.Abs(climbVelocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("IsClimbing", isPlayerHasClimbSpeed);
    }

}
