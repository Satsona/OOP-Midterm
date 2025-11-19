using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public bool isGrounded = false;
    public int health = 100;
    public bool dead = false;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    // Basic Move Method
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }

    // Basic Jump Method
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

   // Method WITH PARAMETERS
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;
    }

    // Method WITH RETURN VALUE
    public bool IsDead()
    {
        return health <= 0;
        dead = true;
    }

    // OVERLOADED METHOD 
    public void Heal()
    {
        health += 10; 
    }

    public int GetHealth()
    {
        return health;
    }

    public void Heal(int amount)
    {
        health += amount;
    }

    // ====== COLLISION METHODS ======

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
