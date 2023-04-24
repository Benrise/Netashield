using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Animator _animJump;
    [SerializeField] private Animator _animRun;
    [SerializeField] private Animator _animIdle;
    [SerializeField] private GameObject _triggerUpStairs;
    [SerializeField] private GameObject _triggerDownStairs;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animJump = GetComponent<Animator>();
        _animRun = GetComponent<Animator>();
        _animIdle = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            _triggerDownStairs.SetActive(true);
            _triggerUpStairs.SetActive(true);
        }
    }


    [SerializeField]public void Move(float direction, bool isJumpButtonPressed)
    {
        if (direction == 0 && isJumpButtonPressed == false)
        {
            _animIdle.SetTrigger("isIdle");
        }

        if (isJumpButtonPressed && isGrounded)
        {
            _animJump.SetTrigger("isJump");
            isGrounded = false;
            rb.AddForce(new Vector2(0, _jumpForce));
        }

        if (direction != 0)
        {
            if (direction > 0 && sp.flipX)
            {
                sp.flipX = !sp.flipX;
            }

            else if (direction < 0 && !sp.flipX)
            {
                sp.flipX = !sp.flipX;
            }
            HorizontalMovement(direction);
        }

    }


    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * _speed, rb.velocity.y);
        _animRun.SetTrigger("isRun");
    }
}