using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [Header("Player Core Component")]
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject ground;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private bool isFacingRight = true;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody2D>();
        anim = body.GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        //    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        HandleUserInputs();

        HandleAnimation();

        HandleFlip();

        SyncPlayerPosition();
    }


    private void HandleUserInputs()
    {
        HandleMove();

        HandleJump(rb);

    }

    private void HandleAnimation()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetBool("isMoving", isMoving);
        // Example: animator.SetBool("isJumping", !Mathf.Approximately(rb.velocity.y, 0));
    }

    private void HandleMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump(Rigidbody2D rb)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void HandleFlip()
    {
        if (rb.velocity.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        rb.transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    private void SyncPlayerPosition()
    {
        Vector3 groundPosition = ground.transform.position;
        groundPosition.x = body.transform.position.x;
        ground.transform.position = groundPosition;
    }
}
