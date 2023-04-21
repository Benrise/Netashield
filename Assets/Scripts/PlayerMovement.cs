    using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float _speed;
    [SerializeField] private bool isFlipRight = true;
    [SerializeField] private Animator _animJump;
    [SerializeField] private Animator _animRun;
    [SerializeField] private Animator _animIdle;
    private Rigidbody2D rb;

    public VectorValue pos;

    private void Awake()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        _animJump = GetComponent<Animator>();
        _animRun = GetComponent<Animator>();
        _animIdle = GetComponent<Animator>();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }


    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (direction == 0 && isJumpButtonPressed == false)
        {
            _animIdle.SetTrigger("isIdle");
        }

        if (isJumpButtonPressed && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, _jumpForce));
            _animJump.SetTrigger("isJump");
        }

        if (direction != 0)
        {
            if (direction > 0 && !isFlipRight)
            {
                Flip();
            }

            else if (direction < 0 && isFlipRight)
            {
                Flip();
            }
            HorizontalMovement(direction);
        }
 
    }


    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * _speed, rb.velocity.y);
        _animRun.SetTrigger("isRun");
    }

    public void Flip()
    {
        isFlipRight = !isFlipRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
