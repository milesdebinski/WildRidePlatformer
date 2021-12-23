using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField] int playerLives = 5;
  [SerializeField] int score = 0;
  [SerializeField] int deathDelay = 3;

  [SerializeField] TextMeshProUGUI livesText;
  [SerializeField] TextMeshProUGUI scoreText;


  void Awake()
  {
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
    if (numGameSessions > 1)
    {
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start()
  {
    livesText.text = playerLives.ToString();
    scoreText.text = score.ToString();
  }

  public void AddToScore()
  {
    score += 100;
    scoreText.text = score.ToString();

  }

  public void ProcessPlayerDeath()
  {
    if (playerLives > 1)
    {
      TakeLive();
    }
    else
    {
      ResetGameSession();
    }
  }

  void TakeLive()
  {
    playerLives--;
    livesText.text = playerLives.ToString();
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void ResetGameSession()
  {
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
}
