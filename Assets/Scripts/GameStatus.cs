using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//TODO: save gameobject through levels
public class GameStatus : MonoBehaviour
{
    //Config Parameters
    [Range(0.1f, 5.0f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int playerScore = 0;
    [SerializeField] TextMeshProUGUI scoreText = null;
    int pointsToAdd = 50;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        UpdateScoreText();
    }
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        playerScore += pointsToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
