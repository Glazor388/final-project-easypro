using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private int lives;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLives()
    {
        return lives;
    }
    
    public void DecreaseLives(int decreaseLives)
    {
        lives -= decreaseLives;
        text.text = "Lives: " + lives;
    }

    public void StartLives(int instantLives)
    {
        lives = instantLives;
        text.text = "Lives: " + lives;
    }
    
}
