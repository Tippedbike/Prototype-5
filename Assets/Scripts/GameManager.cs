using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; 
    private float spawnRate = 1.0f;
    private int score; 
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText; 
    public TextMeshProUGUI livesText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    
    // Start is called before the first frame update

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty; 
        StartCoroutine(SpawnTarget());
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(0);
        isGameActive = true; 
        titleScreen.gameObject.SetActive(false);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
    void Update()
    {
    
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive) 
         {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]); 
         }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }
    public void UpdateLives(int livesToSubtract)
    {
        lives -= livesToSubtract;
        livesText.text = "Lives: " + lives;
        if(lives == 0)
        {
            GameOver();
        }
    }
    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true); 
        isGameActive = false; 
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
