using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public GameObject hazardPrefab;
    public Vector3 spawnValue;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private int score;
    private bool isGameOver;
    private bool restartGame;

    private void Start()
    {
        score = 0;
        isGameOver = false;
        restartGame = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScoreText();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(restartGame)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!isGameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazardPrefab, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddToScore(int value)
    {
        score = score + value;
        UpdateScoreText();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        isGameOver = true;

        restartText.text = "Restart? [R]";
        restartGame = true;
    }
}
