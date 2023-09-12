using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    public float playerSpeed;
    public float horizontalInput;
    public float jumpForce;
    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool jumping;

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(playerRigidBody.transform.position, groundCheckCircle, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            jumping = true;
            jumpTimeCounter = jumpTime;
            playerRigidBody.velocity = Vector2.up * jumpForce;         
        }

        if (Input.GetKey(KeyCode.W) && jumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRigidBody.velocity = (Vector2.up * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        } else
        {
            jumping = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            jumping = false;
        }

    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {

        playerRigidBody.velocity = new Vector2(horizontalInput * playerSpeed, playerRigidBody.velocity.y);

    }
}
