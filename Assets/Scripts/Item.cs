using UnityEngine;

public class Item : MonoBehaviour
{
    public int value = 10;          
    public string itemName = "Gem";  
    public bool isCollected = false; 
    public float rotateSpeed = 50f;
    private bool isSpinning = false;
    private GameManager gm;          


    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Rotate();
    }



    private void Rotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        isSpinning = true;
    }

    // Method WITH PARAMETERS
    public void SetValue(int amount)
    {
        value = amount;
    }

    // Method WITH RETURN VALUE
    public bool IsCollected()
    {
        return isCollected;
    }

    // OVERLOADED METHOD
    public void Collect()
    {
        Collect(value); 
    }

    public void Collect(int customValue)
    {
        if (isCollected) return;

        isCollected = true;
        gm.AddScore(customValue);   // Add score to GameManager
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Collect();
        }
    }
}
