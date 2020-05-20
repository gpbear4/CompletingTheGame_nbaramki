using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameRunning;
    public Button restartButton;
    private int score = 0;
    private SpawnRate spawnRate;
    public GameObject titleScreen;

    class SpawnRate
    {
        private float baseRate;
        private int difficulty;

        public SpawnRate(int diff)
        {
            baseRate = 1.0f;
            difficulty = diff;
        }

        public float GetRate()
        {
            return baseRate / difficulty;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(int difficulty)
    {
        spawnRate = new SpawnRate(difficulty);
        Debug.Log("Spawn rate = " + spawnRate.GetRate());
        titleScreen.gameObject.SetActive(false);
        isGameRunning = true;
        StartCoroutine(TargetSpawner());
        UpdateScore(0);
    }

    IEnumerator TargetSpawner()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate.GetRate());
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }
    public void UpdateScore(int delta)
    {
        if (isGameRunning)
        {
            score += delta;
            if (score < 0)
            {
                score = 0;
            }
            scoreText.text = "Score: " + score;
        }
    }
    public void GameOver()
    {
        isGameRunning = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
