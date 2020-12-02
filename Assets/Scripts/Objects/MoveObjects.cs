using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
   
    public float speed;
    public float newSpeed;
    public float Amplitude;

    public bool isZigZag;
    public bool isDiagonal;

    public Vector2 target;

    Rigidbody2D rb;

    Vector2 force;
    Vector3 point;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        FallMethod();
    }

    void FallMethod()
    {
        if (isZigZag)
        {
            StartCoroutine(Move());
        }

        if (isDiagonal)
        {

            force = new Vector2(Random.Range(-1, 1), -1);
            rb.velocity = force.normalized * speed;
        }
        else
        {
            force = new Vector2(0, -1);
            rb.velocity = force.normalized * speed;
        }
    }

    IEnumerator Move()
    {
        point = gameObject.transform.position;
        while (true)
        {
            point = Vector3.MoveTowards(point, target, Time.deltaTime * speed / 2);
            transform.position = point + transform.right * Mathf.Sin(Time.time * 4) * Amplitude;
            yield return null;
        }
    }

}
 