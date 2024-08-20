using UnityEngine;

public class FireballsMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxSpeed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(-1, 0) * Time.deltaTime, ForceMode2D.Impulse);
        if(rb.velocity.magnitude > maxSpeed) 
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character.currentHp -= 10;
        }
    }
}
