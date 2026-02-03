using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    [SerializeField]private GameManager gameManager;

    private Lives lives;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = FindAnyObjectByType<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Good>(out Good good))
        {
            lives.DecreaseLives(gameManager.decreaseLives);
        }
        
    }
}
