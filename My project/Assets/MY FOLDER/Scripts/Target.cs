using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody targetRb;
     private float minTorque = -10;
     private float maxTorque = 10;
     private float maxForce = 16;
     private float minForce = 12;
     private float minPositionX = -4;
     private float maxPositionX = 4;
     private float positionY = 6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        ForceRandom();
        TorqueRandom();
        SetPosition();
        OnMouseDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TorqueRandom()
    {
        targetRb.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque,maxTorque), Random.Range(minTorque,maxTorque) ,ForceMode.Impulse);
    }

    private void ForceRandom()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minForce,maxForce), ForceMode.Impulse);
    }

    private void SetPosition()
    {
        transform.position = new Vector3(Random.Range(minPositionX,maxPositionX), positionY);
    }

    private void OnMouseDown()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
        {
                Destroy(gameObject);
        }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    
}
