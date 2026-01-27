using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;  
    
    [SerializeField] private int score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartScore();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = "Score: " + score;
    }

    public void StartScore()
    {
        score = 0;
        text.text = "Score: " + score;
    }
    
}
