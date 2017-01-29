using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    
    
    private Lives lives;
    private RespawnManager respawn;
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float minHealth = 0.0f;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthStatus;
    private SpriteRenderer sr;
    [SerializeField]
    private float respawnTime;

    private void Awake()
    {

        lives = GameObject.FindGameObjectWithTag("Player").GetComponent<Lives>();
        sr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        respawn = GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnManager>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        
        

    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }


    void UpdateHealth()
    {

        float healthPercent = currentHealth / maxHealth;
        
        healthBar.rectTransform.localScale = new Vector3(healthPercent, 1, 1);
        
        healthStatus.text = (healthPercent * 100.0f).ToString() + "%";
        
        

    }
    
    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealth();
    }

    public void RemoveHealth(float amount)
    {
        currentHealth -= amount;
        if((currentHealth - amount) <= 0.0f)
        {
            currentHealth = 0.0f;
            lives.LoseLife();
            respawn.isDead = true;
        }
        UpdateHealth();
        
      
    }

    
}
