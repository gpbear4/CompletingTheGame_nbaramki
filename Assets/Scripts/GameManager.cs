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
    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        StartCoroutine(TargetSpawner());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TargetSpawner()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(1.0f);
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
