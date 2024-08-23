using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Animator animator;
    [FormerlySerializedAs("Player")] public GameObject player;
    public bool isRightSide = true;
    public bool isLanded = false;
    public bool isJumped = false;
    public bool isAttacked = false;
    public bool isDead = false;
    public bool takeDamage;
    private float _speed = 5f;
    private const float JumpForce = 300f;
    public Rigidbody2D rb;
    private const float AttackAnimationTime = 0.5f;
    private const float EnableBoxCollider2D = 0.4f;
    private const float DamagedTime = 0.5f;
    public float currentHp;
    public float maxHp = 100f;
    public Image healthBar;
    private Collider2D _getCollider;
   

    
    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        _getCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHp / maxHp, 0, 1);
        
        Move();
        
        Jump();
        
        Attack();

        DropDown();
        
        CharacterDie();
        
    }

    private void Move()
    {
        var moveX = Input.GetAxis("Horizontal") * _speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
        animator.SetFloat("Speed", Math.Abs(moveX));
        if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide)) //Если игрок начал двигаться в противоположную сторону
        { 
            if (moveX != 0f) //Если он не стоит
            {
                Spin();
            }
        }
    }
    
    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isLanded)
            {
                rb.AddForce(Vector2.up * JumpForce);
                isLanded = false;
                animator.SetBool("IsLanded", isLanded);
                isJumped = true;
                animator.SetBool("IsJumped", isJumped);
            }
        } 
    }

    private void DropDown()
    {
        if (currentHp == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _getCollider.enabled = false;
            StartCoroutine(EnableBoxCollider());
        }
    }

    private IEnumerator EnableBoxCollider()
    {
        yield return new WaitForSeconds(EnableBoxCollider2D);
        _getCollider.enabled = true;
    }
    
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacked = true;
            animator.SetBool("IsAttacked", isAttacked);
            StartCoroutine(AttackTime());
        }
    }

    private IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(AttackAnimationTime);
        isAttacked = false;
        animator.SetBool("IsAttacked", isAttacked);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void OnTriggerEnter2D(Collider2D collision)
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
    private IEnumerator Damaged()
    {
        yield return new WaitForSeconds(DamagedTime);
        takeDamage = false;
        animator.SetBool("TakeDamage", takeDamage);
    }

    private void CharacterDie()
    {
        if (currentHp == 0)
        {
            isDead = true;
            animator.SetBool("IsDead", isDead);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (isLanded)
            {
                isLanded = false;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            _speed = 0;
        }
    }
}
