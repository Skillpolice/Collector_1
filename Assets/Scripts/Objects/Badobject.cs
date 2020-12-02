using UnityEngine;
using System.Collections;

public class CookAll : MonoBehaviour
{
    public float speed;
    public float newSpeed;

    public BadObject badObject;
    public AudioClip cartClip;

    Rigidbody2D rb;
    GameManager gameManager;

    Vector2 force;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        if (gameManager.score > 5)
        {
            speed = newSpeed;
        }
        FallMethod();
    }

    void FallMethod()
    {
        force = new Vector2(0, -1);
        rb.velocity = force.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cart"))
        {
            audioManager.PlaySound(cartClip);
            StartCoroutine(Search());
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Search()
    {
        badObject.CookAll();
        yield return new WaitForSeconds(10.0f);
        badObject.NotCookAll();
        Destroy(gameObject);
    }
}

