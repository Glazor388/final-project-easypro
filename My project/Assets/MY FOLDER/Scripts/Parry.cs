using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private int cost = 3;
    
    private Score _score;
    
    private float addForce = 14;
    
    public GameObject parryObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ParryCaroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ParryCaroutine()
    {
        if (Input.GetKeyDown("Space"))
        {
            parryObject.SetActive(true);
            
        }
        yield return new WaitForSeconds(1f);
        parryObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Good>(out Good good))
        {
            _score.AddScore(cost);
            good.GetComponent<Rigidbody>().AddForce(Vector3.up * addForce, ForceMode.Impulse);
        }
    }
    
}
