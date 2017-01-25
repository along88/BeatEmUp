using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
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

    void Start()
    {
        currentHealth = maxHealth;
        
        

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
        if((currentHealth - amount) <= 0)
        {
            currentHealth = 0.0f;
        }
        UpdateHealth();
        
      
    }
}
