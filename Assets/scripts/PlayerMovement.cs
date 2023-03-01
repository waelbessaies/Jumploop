using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheck;
    private Animator anim;
    private enum MovementState { idle, running, jumping, falling }
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheck, groundLayer);


        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
        AnimationUpdate();



    }
    private void AnimationUpdate()
    {
        MovementState state;
        if (input > 0f)
        {
            state = MovementState.running;
        }
        else if (input < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (playerRb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (playerRb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
}



