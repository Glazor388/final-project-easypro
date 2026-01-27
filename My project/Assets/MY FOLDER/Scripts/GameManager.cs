using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText;
    
    public Button RestartButton;
    
    public List<GameObject> targets;
    public bool isGameActive;

    [SerializeField] private float spawnRate;
    
    [SerializeField] private Score score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
    
}
