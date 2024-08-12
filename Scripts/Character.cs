using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;
    public bool isRightSide = true;
    public bool isLanded = false;
    public bool isJumped = false;
    public bool isAttacked = false;
    float speed = 7f;
    private float jumpForce = 300f;
    public Rigidbody2D rb;
   

    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
        animator.SetFloat("Speed", Math.Abs(moveX));
        
        if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide)) //Если игрок начал двигаться в противоположную сторону
        {
            if (moveX != 0f) //Если он не стоит
            {
                Spin();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }

    void Jump()
    {
        if (isLanded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isLanded = false;
            animator.SetBool("IsLanded", isLanded);
            isJumped = true;
            animator.SetBool("IsJumped", isJumped);
        }
    }

    void Attack()
    {
        isAttacked = true;
        animator.SetBool("IsAttacked", isAttacked);
        StartCoroutine(AttackTime());
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacked = false;
        animator.SetBool("IsAttacked", isAttacked);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isLanded = true;
            animator.SetBool("IsLanded", isLanded);
            isJumped = false;
            animator.SetBool("IsJumped", isJumped);
        }
        
    }
}
