using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float jump = 13;
    float xMove = 0;
    float speed = 13f;
    Movement movement;
    Vector2 movementVector;
    bool isGrounded = false;
    private bool jumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movement = new Movement();
        movement.Enable();
    }

    private void FixedUpdate()
    {
        movementVector = movement.Player.Move.ReadValue<Vector2>();
        float jumpValue = movement.Player.Jump.ReadValue<float>();

        Move();

        if(isGrounded)
            Jump(jumpValue);

    }

    private void JumpRelease()
    {

    }

    private void Jump(float jumpValue)
    {
        rb.AddForce(new Vector2(0, jump) * jumpValue, ForceMode2D.Impulse);
    }

    private void Move()
    {
        if (movement.Player.Move.inProgress)
        {
            xMove = movementVector.x;
            speed = 10f;
            var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
            transform.position += (Vector3)mover;
        }
        else if (movementVector == Vector2.zero)
        {
            if (jumping)
                speed = 8f;
            else
                speed = Mathf.MoveTowards(speed, 0, 1.5f);
            var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
            transform.position += (Vector3)mover;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D point = collision.GetContact(0);
        if(point.point.y < transform.position.y)
        {
            isGrounded = true;
            jumping = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D point = collision.GetContact(0);
        if (point.point.y < transform.position.y)
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumping = true;
    }
}