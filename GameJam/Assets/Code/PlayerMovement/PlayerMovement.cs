using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    ContactPoint2D point;
    float jump = 13;
    float xMove = 0;
    private float xJump;
    float speed = 13f;
    float jumpValue;
    Movement movement;
    Vector2 movementVector;
    bool isGrounded = false;
    private bool jumping;
    float jumpHeight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movement = new Movement();
        movement.Enable();
    }

    private void FixedUpdate()
    {
        movementVector = movement.Player.Move.ReadValue<Vector2>();
        jumpValue = movement.Player.Jump.ReadValue<float>();

        Move();

        if (isGrounded)
            Jump();

    }

    private void Jump()
    {
            rb.AddForce(new Vector2(0, jump) * jumpValue, ForceMode2D.Impulse);
    }

    private void Move()
    {
        if (movement.Player.Move.inProgress)
        {
            xMove = movementVector.x;
            xJump = xMove;
            speed = 10f;
            var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
            transform.position += (Vector3)mover;
        }
        else if (movementVector == Vector2.zero)
        {
            if (jumping)
            {
                var mover = new Vector2(xJump, 0) * Time.fixedDeltaTime * speed;
                transform.position += (Vector3)mover;
            }
            else
            {
                speed = Mathf.MoveTowards(speed, 0, 1f);
                var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
                transform.position += (Vector3)mover;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        point = collision.GetContact(0);
        if(point.point.y < transform.position.y)
        {
            isGrounded = true;
            jumping = false;
            xJump = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        point = collision.GetContact(0);
        if (point.point.y < transform.position.y)
        {
            isGrounded = true;
            jumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumping = true;
    }
}