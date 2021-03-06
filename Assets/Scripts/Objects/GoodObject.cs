﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodObject : MonoBehaviour
{
    public int pointDamage;
    public int pointScore;

    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            gameManager.AddScore(pointScore);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WallButtom"))
        {
            gameManager.Damage(pointDamage);
            Destroy(gameObject);
        }
    }
}
