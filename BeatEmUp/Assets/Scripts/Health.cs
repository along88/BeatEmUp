using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    protected float currentHealth;

    //FIX:This is not clamping the currentHealth value 
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            
        }
    }

    public void RemoveHealth(float amount)
    {
        if(amount < CurrentHealth)
        {
            CurrentHealth -= amount;
        }
        else if(amount >= CurrentHealth)
        {
            CurrentHealth = 0.0f; //remove this "else if" if property field for CurrentHealth has been fixed
        }
    }

    public void AddHealth(float amount)
    {
        if(amount >= maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        else if(amount < 0)
        {
            CurrentHealth = CurrentHealth;
        }
        else
        {
            CurrentHealth += amount;
        }
    }
}
