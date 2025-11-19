using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pointA;       
    public Transform pointB;        
    public float speed = 2f;       
    public int damage = 20;         
    private bool goingToB = true;   
    private GameManager gm;         


    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Patrol();
    }



    private void Patrol()
    {
        Transform target = goingToB ? pointB : pointA;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Switch direction when reaching target
        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            goingToB = !goingToB;
        }
    }

    // Method WITH PARAMETERS 
    public void SetDamage(int amount)
    {
        damage = amount;
    }

    // Method WITH RETURN VALUE 
    public bool IsGoingToB()
    {
        return goingToB;
    }

    // OVERLOADED METHOD 
    public void AttackPlayer(Player player)
    {
        player.TakeDamage(damage);
    }

    public void AttackPlayer(Player player, int customDamage)
    {
        player.TakeDamage(customDamage);
    }

    private void HitPlayer(Player player)
    {
        AttackPlayer(player);
    }


    // ====== COLLISION DETECTION ======
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();

            if (player != null)
                HitPlayer(player);
        }
    }
}
