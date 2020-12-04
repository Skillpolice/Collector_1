using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] heart;

    [Header("Text")]
    public Text scoreText;
    public Text healthText;

    [Header("Lifes")]
    public int lifeCount;

    [Header("Pad")]
    public Pad pad;

    [Header("Pause - GameOver Panel")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    [HideInInspector]
    public bool isPauseActive;

    [HideInInspector]
    public int score;

    private void Start()
    {
        scoreText.text = "Point:  ";
    }

    private void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isPauseActive)
            {
                Time.timeScale = 1;
                isPauseActive = false;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                isPauseActive = true;
                Cursor.visible = true;
            }
            pausePanel.SetActive(isPauseActive);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Point: " +  score.ToString();
    }

    public void LoseLife()
    {
        lifeCount--;
        healthText.text = "Health: " + lifeCount.ToString();

        if(lifeCount <= 0)
        {
            isPauseActive = true;
            gameOverPanel.SetActive(true);
            Cursor.visible = true;
        }
        gameOverPanel.SetActive(isPauseActive);
    }
    public void Damage(int damage)
    {
        lifeCount += damage;

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < lifeCount)
            {
                heart[i].gameObject.SetActive(true);
            }
            else
            {
                heart[i].gameObject.SetActive(false);
            }
        }

        if (lifeCount <= 0)
        {
            isPauseActive = true;
            gameOverPanel.SetActive(true);
            Cursor.visible = true;
        }
    }
    public void RestartLevel()
    {
        lifeCount = 3;
        score = 0;

        isPauseActive = false;
        gameOverPanel.SetActive(false);

        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);

        scoreText.text = "Point: 000";
        healthText.text = "Health: " + lifeCount.ToString();
    }

}
