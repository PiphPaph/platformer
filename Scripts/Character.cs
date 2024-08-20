using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public bool isRightSide = true;
    public bool isLanded = false;
    public bool isJumped = false;
    public bool isAttacked = false;
    public bool isDead = false;
    public bool takeDamage;
    float speed = 7f;
    private float jumpForce = 300f;
    public Rigidbody2D rb;
    private float attackAnimationTime = 0.5f;
    private float enableBoxCollider2D = 0.4f;
    private float damagedTime = 0.5f;
    public static float currentHp;
    public float maxHp = 100f;
    public Image healthBar;
   

    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHp / maxHp, 0, 1);
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            DropDown();
        }

        if (currentHp == 0)
        {
            CharacterDie();
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

    void DropDown()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(enableBoxCollider());
    }

    IEnumerator enableBoxCollider()
    {
        yield return new WaitForSeconds(enableBoxCollider2D);
        GetComponent<Collider2D>().enabled = true;
    }
    
    void Attack()
    {
        isAttacked = true;
        animator.SetBool("IsAttacked", isAttacked);
        StartCoroutine(AttackTime());
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(attackAnimationTime);
        isAttacked = false;
        animator.SetBool("IsAttacked", isAttacked);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Sides"))
        {
            isLanded = true;
            animator.SetBool("IsLanded", isLanded);
            isJumped = false;
            animator.SetBool("IsJumped", isJumped);
        }
        if (collision.gameObject.CompareTag("FooterRespawn"))
        {
            transform.position = new Vector2(-7, -3);
            currentHp -= 10;
            takeDamage = true;
            animator.SetBool("TakeDamage", takeDamage);
            StartCoroutine(Damaged());
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kitty"))
        {
            transform.position = new Vector2(-7, -3);
        }

        if (collision.gameObject.CompareTag("Fireball"))
        {
            takeDamage = true;
            animator.SetBool("TakeDamage", takeDamage);
            StartCoroutine(Damaged());
        }
    }
    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(damagedTime);
        takeDamage = false;
        animator.SetBool("TakeDamage", takeDamage);
    }

    void CharacterDie()
    {
        isDead = true;
        animator.SetBool("IsDead", isDead);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        speed = 0;
    }
}
