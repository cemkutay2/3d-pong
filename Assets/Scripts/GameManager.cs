using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score;
    // spawn manager
    [SerializeField] private GameObject coinPrefab;
    private float xRange = 5.75f;
    private float yMaxRange = 8.90f;
    private float yMinRange = 2f;

    public void StartGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        score = 0;
        SpawnCoinAtRandom();
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void SpawnCoinAtRandom()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), Random.Range(yMinRange, yMaxRange), 9.5f);
        Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
