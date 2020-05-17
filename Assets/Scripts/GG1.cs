﻿using UnityEngine;

using System.Collections;

public class  GG1: MonoBehaviour
{
    private bool isGrounded = false;

    public Transform groundCheck;

    private float groundRadius = 0.2f;

    public LayerMask whatIsGround;

    public float maxSpeed = 10f;

    private bool isFacingRight = true;

    private Rigidbody2D rigid;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");
        if (move == 0)
        {
            anim.SetFloat("Speed", -1);
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
        }

        rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        print(isGrounded);
        anim.SetBool("Ground", isGrounded);

        anim.SetFloat("vSpeed", rigid.velocity.y);

        if (!isGrounded)
        {
            anim.SetBool("Fire", false);
            return;
        }
        
        if (Input.GetButtonUp("Fire"))
        {
            anim.SetBool("Fire", false);
        }

        if (Input.GetButtonDown("Fire"))
        {
            anim.SetBool("Fire", true);
        }
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {

            anim.SetBool("Ground", false);

            rigid.AddForce(new Vector2(0, 600));
        }
    }


    private void Flip()
    {

        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}