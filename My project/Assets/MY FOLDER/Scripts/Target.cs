using System.Net;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private int cost;
    [SerializeField] private ParticleSystem particles;
    
     public Rigidbody targetRb;
     
     private float _minTorque = -2;
     private float _maxTorque = 2;
     private float _maxForce = 16;
     private float _minForce = 12;
     private float _minPositionX = -4;
     private float _maxPositionX = 4;
     private float _positionY = 1;
     
     private Score _score;
     private Lives _lives;
     private GameManager _gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        _score = FindAnyObjectByType<Score>();
        _lives = FindAnyObjectByType<Lives>();
        _gameManager = FindAnyObjectByType<GameManager>();
        
        ForceRandom();
        TorqueRandom();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TorqueRandom()
    {
        targetRb.AddTorque(Random.Range(_minTorque, _maxTorque), Random.Range(_minTorque,_maxTorque), Random.Range(_minTorque,_maxTorque) ,ForceMode.Impulse);
    }

    private void ForceRandom()
    {
        targetRb.AddForce(Vector3.up * Random.Range(_minForce,_maxForce), ForceMode.Impulse);
    }

    private void SetPosition()
    {
        transform.position = new Vector3(Random.Range(_minPositionX,_maxPositionX), _positionY);
    }

    public void DestroyTarget()
    {
        if (_gameManager.isGameActive)
        {
            if (gameObject.TryGetComponent<Bad>(out Bad bad))
            {
                GameManager gameManager = FindFirstObjectByType<GameManager>();
                _lives.DecreaseLives(_gameManager.decreaseLives);
            }
            else
            {
                _score.AddScore(cost);
                Instantiate(particles,transform.position,particles.transform.rotation);            
            }

            Destroy(gameObject);             
        }
          
    }
    
}
