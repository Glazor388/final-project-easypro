using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText;
    public GameObject pauseMenu;
    
    public int decreaseLives = 1;
    
    public Button RestartButton;
    
    public List<GameObject> targets;
    public bool isGameActive;

    [SerializeField] private float spawnRate;
    
    
    
    [SerializeField] private Score score;
    [SerializeField] private Lives lives;

    private bool isPaused = false;
    
    private int instantlives = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives.StartLives(instantlives);
    }

    void Update()
    {
        if (lives.GetLives() <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int index = Random.Range(0, targets.Count);
            
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        RestartButton.gameObject.SetActive(true);
        isGameActive = false;
        GameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score.StartScore();
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = 0;            
        }
        else
        {
            isPaused = false;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = 1;
        }

    }
    
}
