using UnityEngine;

public class FireballsMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _maxSpeed = 8f;
    public Character playerCharacter;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.AddForce(new Vector2(-1, 0) * Time.deltaTime, ForceMode2D.Impulse);
        if(_rb.velocity.magnitude > _maxSpeed) 
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCharacter.currentHp -= 10;
        }
    }
}
