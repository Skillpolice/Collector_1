using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public int pointDamage;
    public float speed;
    Rigidbody2D rb;
    GameManager gameManager;

    Vector2 force;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void FallMethod()
    {
        force = new Vector2(0, -1);
        rb.velocity = force.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            gameManager.Damage(pointDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WallButtom"))
        {
            Destroy(gameObject);
        }
    }
}

