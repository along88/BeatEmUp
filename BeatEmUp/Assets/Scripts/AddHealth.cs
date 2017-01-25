using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private Health playerHealth;

    private int numberOfHits;
    [SerializeField]
    private int hitAmount;
    [SerializeField]
    private float damage;
   

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Start()
    {
        numberOfHits = 0;
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            numberOfHits++;
            if (numberOfHits < hitAmount)
                playerHealth.AddHealth(damage);
            else
                Destroy(gameObject);
        }
    }
}
