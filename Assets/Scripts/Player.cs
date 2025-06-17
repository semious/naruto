using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    private Vector3 playerVelocity;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravityValue = -9.81f;

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject ground;

    private void Start()
    {
    }

    private void Update()
    {
        //    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Rigidbody2D rb = body.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
        //controller.Move(transform.TransformDirection(input) * moveSpeed * Time.deltaTime);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);


    }
}
